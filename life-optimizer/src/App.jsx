import { useState, useEffect, useRef } from 'react';
import { Routes, Route, Link, useLocation } from 'react-router-dom';
import StatsChart from './StatsChart';
import QuestCard from './QuestCard';

const DEFAULT_STATS = [
  { subject: 'Health', A: 50, weight: 1.0 },
  { subject: 'Intelligence', A: 50, weight: 1.0 },
  { subject: 'Relationships', A: 50, weight: 1.0 },
  { subject: 'Wealth', A: 50, weight: 1.0 },
  { subject: 'Spiritual', A: 50, weight: 1.0 },
  { subject: 'Purpose', A: 50, weight: 1.0 },
];

// 🔧 Explicitly pointing to your .NET backend server port
const BACKEND_BASE_URL = 'http://localhost:5248';

const apiFetch = async (endpoint, options = {}) => {
  const fullUrl = `${BACKEND_BASE_URL}${endpoint}`;

  const storedUser = (() => { try { return JSON.parse(localStorage.getItem('lifeoptimizer_user')); } catch { return null; } })();
  const userHeader = storedUser?.id ? { 'X-User-Id': String(storedUser.id) } : {};

  try {
    const response = await fetch(fullUrl, {
      ...options,
      headers: { 'Content-Type': 'application/json', ...userHeader, ...(options.headers || {}) },
    });

    if (!response.ok) {
      const errorText = await response.text();
      const message = `API request failed: ${fullUrl} (Status ${response.status}).`;
      console.error(`[API ERROR]`, { fullUrl, status: response.status, body: errorText });
      throw new Error(errorText || message);
    }

    const text = await response.text();
    if (!text) return null;
    return JSON.parse(text);
  } catch (err) {
    const raw = err instanceof Error ? err.message : String(err);
    if (raw === 'Failed to fetch' || raw.toLowerCase().includes('network')) {
      throw new Error(`Network error contacting backend at ${fullUrl}. Is the backend running? (${raw})`);
    }
    throw err;
  }
};

const mapServerStat = (stat) => ({
  id: stat.id,
  subject: stat.subject,
  A: stat.level,
  weight: stat.weight,
});

const mapServerQuestTemplate = (template) => ({
  id: template.id,
  title: template.title,
  stat: template.stat,
  rarity: template.rarity,
  xpReward: template.xpReward,
});

const mapServerActiveQuest = (active) => ({
  id: active.id,
  templateId: active.questTemplate.id,
  title: active.questTemplate.title,
  stat: active.questTemplate.stat,
  rarity: active.questTemplate.rarity,
  xpReward: active.questTemplate.xpReward,
});

function App() {
  const location = useLocation();
  const xpNeededForLevelUp = 100;

  const [globalXp, setGlobalXp] = useState(0);
  const [globalLevel, setGlobalLevel] = useState(1);
  const [questCapacity, setQuestCapacity] = useState(3);
  const [stats, setStats] = useState(DEFAULT_STATS);
  const [masterQuestPool, setMasterQuestPool] = useState([]);
  const [activeDailyQuests, setActiveDailyQuests] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [errorMessage, setErrorMessage] = useState('');

  const [currentUser, setCurrentUser] = useState(() => {
    try { return JSON.parse(localStorage.getItem('lifeoptimizer_user')); }
    catch { return null; }
  });

  const [shareModal, setShareModal] = useState(null);
  const [friends, setFriends] = useState([]);
  const [shareTarget, setShareTarget] = useState('');

  const authFetch = (endpoint, options = {}) => {
    if (!currentUser) throw new Error('Not logged in');
    return apiFetch(endpoint, {
      ...options,
      headers: { 'Content-Type': 'application/json', 'X-User-Id': String(currentUser.id), ...(options.headers || {}) },
    });
  };

  const openShareModal = async (quest) => {
    if (!currentUser) return alert('Log in on the Profile tab to share quests.');
    try {
      const list = await authFetch('/api/friends');
      if (!list.length) return alert('You have no friends added yet. Add friends on the Profile tab first.');
      setFriends(list);
      setShareTarget(list[0].username);
      setShareModal(quest);
    } catch (e) {
      alert(e instanceof Error ? e.message : 'Failed to load friends.');
    }
  };

  const sendShare = async () => {
    if (!shareTarget) return;
    try {
      await authFetch('/api/inbox/send', {
        method: 'POST',
        body: JSON.stringify({ recipientUsername: shareTarget, title: shareModal.title, stat: shareModal.stat, rarity: shareModal.rarity, xpReward: shareModal.xpReward }),
      });
      alert(`Quest shared with ${shareTarget}!`);
      setShareModal(null);
    } catch (e) {
      alert(e instanceof Error ? e.message : 'Failed to share quest.');
    }
  };

  const refreshProfile = async () => {
    const profile = await apiFetch('/api/profile');
    setGlobalXp(profile.globalXp);
    setGlobalLevel(profile.globalLevel);
    setQuestCapacity(profile.questCapacity);
    setStats(profile.stats.map(mapServerStat));
  };

  const refreshQuestTemplates = async () => {
    const templates = await apiFetch('/api/questtemplates');
    setMasterQuestPool(templates.map(mapServerQuestTemplate));
  };

  const refreshActiveDailyQuests = async () => {
    const active = await apiFetch('/api/activequests');
    setActiveDailyQuests(active.map(mapServerActiveQuest));
  };

  useEffect(() => {
    const loadAll = async () => {
      try {
        setIsLoading(true);
        setErrorMessage('');
        setActiveDailyQuests([]);

        await refreshProfile();
        await Promise.all([refreshQuestTemplates(), refreshActiveDailyQuests()]);
      } catch (error) {
        setErrorMessage(error instanceof Error ? error.message : 'Failed to load app data.');
      } finally {
        setIsLoading(false);
      }
    };

    loadAll();
  }, [currentUser?.id]);

  const generateDailyQuests = async () => {
    if (masterQuestPool.length === 0) return alert("Your Blueprint Library is empty!");

    const remaining = Math.max(0, questCapacity - activeDailyQuests.length);
    if (remaining <= 0) return alert('Quest board is full. Complete or remove existing quests first.');

    try {
      await apiFetch('/api/activequests/roll', {
        method: 'POST',
        body: JSON.stringify({ count: remaining }),
      });
      await refreshActiveDailyQuests();
    } catch (error) {
      alert(error instanceof Error ? error.message : 'Failed to roll daily quests.');
    }
  };

  const processQuestCompletion = async (activeQuestId) => {
    try {
      const result = await apiFetch('/api/activequests/complete', {
        method: 'POST',
        body: JSON.stringify({ activeQuestId }),
      });

      await refreshProfile();
      await refreshActiveDailyQuests();

      if (result.levelsGained > 0) {
        if (result.levelsGained === 1) {
          alert(`🎉 LEVEL UP! You reached Global Level ${result.globalLevel}!`);
        } else {
          alert(`🔥 MULTI-LEVEL Surge! You gained +${result.levelsGained} levels at once and reached Level ${result.globalLevel}!`);
        }
      }
    } catch (error) {
      alert(error instanceof Error ? error.message : 'Failed to complete quest.');
    }
  };

  const processQuestReroll = async (activeQuestId) => {
    try {
      const updated = await apiFetch('/api/activequests/reroll', {
        method: 'POST',
        body: JSON.stringify({ activeQuestId }),
      });
      setActiveDailyQuests(prev => prev.map(q =>
        q.id === updated.id ? mapServerActiveQuest(updated) : q
      ));
    } catch (error) {
      alert(error instanceof Error ? error.message : 'Failed to reroll quest.');
    }
  };

  const processQuestDelete = async (activeQuestId) => {
    try {
      if (!window.confirm('Remove this quest for today?')) return;
      await apiFetch(`/api/activequests/${activeQuestId}`, { method: 'DELETE' });
      await refreshActiveDailyQuests();
    } catch (error) {
      alert(error instanceof Error ? error.message : 'Failed to remove quest.');
    }
  };

  const saveSettings = async () => {
    try {
      await apiFetch('/api/profile', {
        method: 'PUT',
        body: JSON.stringify({
          questCapacity,
          stats: stats.map((s) => ({ id: s.id, level: s.A, weight: s.weight })),
        }),
      });
    } catch (error) {
      console.error('Auto-save failed:', error);
    }
  };

  const resetGlobalLevel = async () => {
    if (!window.confirm('Reset global level to 1?')) return;
    try {
      await apiFetch('/api/profile', {
        method: 'PUT',
        body: JSON.stringify({
          questCapacity,
          stats: stats.map((s) => ({ id: s.id, level: s.A, weight: s.weight })),
          globalLevel: 1,
          globalXp: 0,
        }),
      });
      await refreshProfile();
      alert('Global level reset to 1.');
    } catch (error) {
      alert(error instanceof Error ? error.message : 'Failed to reset global level.');
    }
  };

  const createStat = async (subject) => {
    return apiFetch('/api/stats', {
      method: 'POST',
      body: JSON.stringify({ subject, level: 0, weight: 1.0 }),
    });
  };

  const deleteStat = async (statId) => {
    await apiFetch(`/api/stats/${statId}`, { method: 'DELETE' });
  };

  return (
    <div style={{ padding: '20px', maxWidth: '500px', margin: '0 auto', paddingBottom: '80px', color: 'white', minHeight: '100vh', boxSizing: 'border-box', background: 'radial-gradient(ellipse 80% 50% at 15% 0%, rgba(245,158,11,0.09) 0%, transparent 70%), radial-gradient(ellipse 60% 50% at 85% 90%, rgba(251,191,36,0.06) 0%, transparent 70%), radial-gradient(ellipse 50% 40% at 50% 50%, rgba(245,158,11,0.03) 0%, transparent 70%), #0a0900' }}>
      
      {location.pathname === '/' && <header style={{
        marginBottom: '24px',
        textAlign: 'center',
        padding: '20px 16px 18px',
        background: 'linear-gradient(160deg, #1c1200 0%, #0a0900 100%)',
        borderRadius: '0 0 24px 24px',
        borderBottom: '1px solid rgba(245,158,11,0.15)',
        boxShadow: '0 4px 24px rgba(245,158,11,0.07)',
        margin: '0 -20px 24px -20px',
      }}>
        <h1 style={{
          margin: '0 0 2px 0',
          fontSize: '1.4rem',
          fontWeight: 900,
          letterSpacing: '4px',
          background: 'linear-gradient(90deg, #f59e0b, #fbbf24, #f59e0b)',
          WebkitBackgroundClip: 'text',
          WebkitTextFillColor: 'transparent',
          textShadow: 'none',
        }}>ASCENT</h1>

        <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', gap: '10px', margin: '10px 0 8px 0' }}>
          <span style={{ fontSize: '0.7rem', color: '#555', letterSpacing: '1px', textTransform: 'uppercase' }}>Level</span>
          <span style={{ fontSize: '1.1rem', fontWeight: 800, color: '#fbbf24' }}>{globalLevel}</span>
          <span style={{ width: '1px', height: '12px', background: '#333' }} />
          <span style={{ fontSize: '0.75rem', color: '#555' }}>{globalXp} <span style={{ color: '#383858' }}>/</span> {xpNeededForLevelUp} XP</span>
        </div>

        <div style={{ width: '100%', maxWidth: '280px', height: '8px', backgroundColor: 'rgba(255,255,255,0.05)', borderRadius: '99px', margin: '0 auto', overflow: 'hidden', border: '1px solid rgba(245,158,11,0.2)' }}>
          <div style={{
            width: `${(globalXp / xpNeededForLevelUp) * 100}%`,
            height: '100%',
            background: 'linear-gradient(90deg, #d97706, #f59e0b, #fbbf24)',
            borderRadius: '99px',
            transition: 'width 0.5s cubic-bezier(0.4,0,0.2,1)',
            boxShadow: '0 0 10px rgba(245,158,11,0.5)',
          }} />
        </div>
      </header>}

      {isLoading && (
        <div style={{ color: '#aaa', fontSize: '0.9rem', textAlign: 'center', marginBottom: '20px' }}>
          Loading app data...
        </div>
      )}
      {errorMessage && (
        <div style={{ color: '#ff6b6b', fontSize: '0.9rem', textAlign: 'center', marginBottom: '20px' }}>
          {errorMessage}
        </div>
      )}

      <main>
        <Routes>
          <Route path="/" element={
            <div>
              <h2 style={{ borderBottom: '1px solid #444', paddingBottom: '10px' }}>Current Build</h2>
              <StatsChart key={JSON.stringify(stats)} stats={stats} /> 

              <div style={{ marginTop: '30px' }}>
                <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '15px' }}>
                  <h3 style={{ margin: 0 }}>Today's Active Board</h3>
                  <button
                    onClick={generateDailyQuests}
                    disabled={activeDailyQuests.length >= questCapacity || masterQuestPool.length === 0}
                    style={{ background: 'transparent', border: '1px solid #f59e0b', color: '#f59e0b', padding: '6px 12px', borderRadius: '20px', fontSize: '0.75rem', fontWeight: 'bold', cursor: (activeDailyQuests.length >= questCapacity || masterQuestPool.length === 0) ? 'not-allowed' : 'pointer', opacity: (activeDailyQuests.length >= questCapacity || masterQuestPool.length === 0) ? 0.5 : 1 }}
                  >
                    🎲 Roll Daily Quests
                  </button>
                </div>

                {activeDailyQuests.length === 0 ? (
                  <p style={{ color: '#444', fontSize: '0.85rem', textAlign: 'center', padding: '20px', border: '1px dashed #333', borderRadius: '8px' }}>
                    {masterQuestPool.length === 0
                      ? 'No quests in library. Add quests in the Quest Library tab before rolling.'
                      : `No assignments loaded. Click "Roll Daily Quests" to populate active trackers (${questCapacity} slots max).`}
                  </p>
                ) : (
                  activeDailyQuests.map(q => (
                    <QuestCard
                      key={q.id}
                      title={q.title}
                      stat={q.stat}
                      rarity={q.rarity}
                      xp={q.xpReward}
                      onComplete={() => processQuestCompletion(q.id)}
                      onReroll={() => processQuestReroll(q.id)}
                      onDelete={() => processQuestDelete(q.id)}
                      onShare={currentUser ? () => openShareModal(q) : null}
                    />
                  ))
                )}
              </div>
            </div>
          } />
          
          <Route path="/quests" element={
            <QuestPage
              stats={stats}
              setStats={setStats}
              masterQuestPool={masterQuestPool}
              setMasterQuestPool={setMasterQuestPool}
              activeDailyQuests={activeDailyQuests}
              setActiveDailyQuests={setActiveDailyQuests}
              onCreateStat={createStat}
              onShare={currentUser ? openShareModal : null}
            />
          } />

          <Route path="/settings" element={
            <SettingsPage
              stats={stats}
              setStats={setStats}
              questCapacity={questCapacity}
              setQuestCapacity={setQuestCapacity}
              onSaveSettings={saveSettings}
              onCreateStat={createStat}
              onDeleteStat={deleteStat}
              onResetGlobalLevel={resetGlobalLevel}
            />
          } />

          <Route path="/profile" element={
            <ProfilePage
              currentUser={currentUser}
              setCurrentUser={(user) => {
                setCurrentUser(user);
                if (user) localStorage.setItem('lifeoptimizer_user', JSON.stringify(user));
                else localStorage.removeItem('lifeoptimizer_user');
              }}
              authFetch={authFetch}
              masterQuestPool={masterQuestPool}
              setMasterQuestPool={setMasterQuestPool}
            />
          } />
        </Routes>
      </main>

      {shareModal && (
        <div style={{ position: 'fixed', top: 0, left: 0, right: 0, bottom: 0, backgroundColor: 'rgba(0,0,0,0.85)', display: 'flex', justifyContent: 'center', alignItems: 'center', zIndex: 6000, padding: '20px' }}>
          <div style={{ backgroundColor: '#1c1c1e', padding: '25px', borderRadius: '16px', border: '1px solid #333', width: '100%', maxWidth: '380px', boxSizing: 'border-box' }}>
            <h3 style={{ margin: '0 0 5px 0', color: '#f59e0b' }}>Share Quest</h3>
            <p style={{ fontSize: '0.8rem', color: '#888', margin: '0 0 20px 0' }}>{shareModal.title}</p>
            <label style={{ fontSize: '0.75rem', fontWeight: 'bold', color: '#aaa', display: 'block', marginBottom: '5px' }}>SEND TO</label>
            <select
              value={shareTarget}
              onChange={(e) => setShareTarget(e.target.value)}
              style={{ width: '100%', padding: '10px', background: '#000', color: '#fff', border: '1px solid #444', borderRadius: '6px', marginBottom: '20px', boxSizing: 'border-box' }}
            >
              {friends.map(f => <option key={f.id} value={f.username}>{f.username}</option>)}
            </select>
            <div style={{ display: 'flex', gap: '10px' }}>
              <button onClick={() => setShareModal(null)} style={{ flex: 1, padding: '12px', background: 'transparent', border: '1px solid #444', color: '#aaa', borderRadius: '8px', cursor: 'pointer', fontWeight: 'bold' }}>Cancel</button>
              <button onClick={sendShare} style={{ flex: 1, padding: '12px', background: '#f59e0b', border: 'none', color: '#fff', borderRadius: '8px', cursor: 'pointer', fontWeight: 'bold' }}>Send</button>
            </div>
          </div>
        </div>
      )}

      <nav style={{
        position: 'fixed', bottom: 0, left: 0, right: 0,
        background: 'rgba(15,15,15,0.85)',
        backdropFilter: 'blur(16px)',
        WebkitBackdropFilter: 'blur(16px)',
        display: 'flex',
        justifyContent: 'space-around',
        padding: '8px 12px 18px',
        borderTop: '1px solid rgba(255,255,255,0.06)',
        zIndex: 1000,
      }}>
        {[
          { to: '/',         icon: '📊', label: 'Dashboard' },
          { to: '/quests',   icon: '📜', label: 'Quest Log' },
          { to: '/settings', icon: '⚙️', label: 'Settings'  },
          { to: '/profile',  icon: '👤', label: currentUser ? currentUser.username : 'Profile' },
        ].map(({ to, icon, label }) => {
          const active = location.pathname === to;
          return (
            <Link key={to} to={to} style={{ textDecoration: 'none', display: 'flex', flexDirection: 'column', alignItems: 'center', gap: '3px', flex: 1, padding: '6px 4px', borderRadius: '14px', background: active ? 'rgba(245,158,11,0.12)' : 'transparent', transition: 'background 0.2s ease' }}>
              <span style={{ fontSize: '1.25rem', lineHeight: 1, filter: active ? 'none' : 'grayscale(0.4) opacity(0.5)' }}>{icon}</span>
              <span style={{ fontSize: '0.58rem', fontWeight: active ? 700 : 500, letterSpacing: '0.4px', textTransform: 'uppercase', color: active ? '#fbbf24' : '#444', whiteSpace: 'nowrap', overflow: 'hidden', textOverflow: 'ellipsis', maxWidth: '64px', textAlign: 'center', transition: 'color 0.2s ease' }}>{label}</span>
            </Link>
          );
        })}
      </nav>
    </div>
  );
}

function QuestPage({ stats, setStats, masterQuestPool, setMasterQuestPool, activeDailyQuests, setActiveDailyQuests, onCreateStat, onShare }) {
  const [title, setTitle] = useState('');
  
  // 1. Initialize it to an empty string.
  const [selectedStat, setSelectedStat] = useState('');
  
  const [rarity, setRarity] = useState('Common');
  const [expandedCategory, setExpandedCategory] = useState(-1);
  
  const [aiPrompt, setAiPrompt] = useState('');
  const [isAiLoading, setIsAiLoading] = useState(false);

  const [showPreviewModal, setShowPreviewModal] = useState(false);
  const [previewTitle, setPreviewTitle] = useState('');
  const [previewStat, setPreviewStat] = useState('');
  const [previewRarity, setPreviewRarity] = useState('Common');

  const rarityXpValues = { Common: 10, Rare: 25, Epic: 50, Legendary: 100 };

  // 🛑 BUGGY USEEFFECT REMOVED ENTIRELY. No more race conditions.

  // 2. Derive the active selection safely. 
  // If selectedStat is blank or doesn't exist in the current stats array, 
  // we fallback to the first stat's subject automatically.
  const currentSelection = stats.some(s => s.subject === selectedStat)
    ? selectedStat 
    : (stats[0]?.subject || '');

  const addQuest = async () => {
    if (!title.trim()) return;

    try {
      const created = await apiFetch('/api/questtemplates', {
        method: 'POST',
        body: JSON.stringify({
          title: title.trim(),
          stat: currentSelection, // Use the safe derived value here
          rarity,
          xpReward: rarityXpValues[rarity],
        }),
      });

      setMasterQuestPool([...masterQuestPool, mapServerQuestTemplate(created)]);
      setTitle('');
    } catch (error) {
      alert(error instanceof Error ? error.message : 'Failed to add quest template.');
    }
  };

  const generateAiQuest = async () => {
    if (!aiPrompt.trim()) return alert("Enter a real-world concept or task first!");

    setIsAiLoading(true);
    try {
      const response = await apiFetch('/api/ai/quest', {
        method: 'POST',
        body: JSON.stringify({
          prompt: aiPrompt,
          attributes: stats.map(s => s.subject),
        }),
      });

      setPreviewTitle(response.title || 'Untitled Quest');
      setPreviewStat(stats.find(s => s.subject === response.stat) ? response.stat : stats[0].subject);
      setPreviewRarity(rarityXpValues[response.rarity] ? response.rarity : 'Common');

      setIsAiLoading(false);
      setShowPreviewModal(true);
    } catch (error) {
      console.warn(error);
      setIsAiLoading(false);
    }
  };

  const commitPreviewQuest = async () => {
    if (!previewTitle.trim()) return alert("Title can't be blank!");

    try {
      const created = await apiFetch('/api/questtemplates', {
        method: 'POST',
        body: JSON.stringify({
          title: previewTitle.trim(),
          stat: previewStat,
          rarity: previewRarity,
          xpReward: rarityXpValues[previewRarity],
        }),
      });

      setMasterQuestPool(prevPool => [...prevPool, mapServerQuestTemplate(created)]);
      setShowPreviewModal(false);
      setAiPrompt('');
    } catch (error) {
      alert(error instanceof Error ? error.message : 'Failed to save AI quest template.');
    }
  };

  const deleteTemplate = async (id) => {
    const affectedActive = activeDailyQuests.filter(q => q.templateId === id);
    if (affectedActive.length > 0) {
      const ok = window.confirm(
        `This quest is currently on your active dashboard. Deleting it from the library will also remove it from today's board. Continue?`
      );
      if (!ok) return;
    }

    try {
      await apiFetch(`/api/questtemplates/${id}`, { method: 'DELETE' });
      setMasterQuestPool(masterQuestPool.filter(q => q.id !== id));
      if (affectedActive.length > 0) {
        const removedIds = new Set(affectedActive.map(q => q.id));
        setActiveDailyQuests(prev => prev.filter(q => !removedIds.has(q.id)));
      }
    } catch (error) {
      alert(error instanceof Error ? error.message : 'Failed to delete template.');
    }
  };

  const grouped = stats.reduce((acc, s) => {
    acc[s.subject] = masterQuestPool.filter(q => q.stat === s.subject);
    return acc;
  }, {});

  return (
    <div>
      <h3>Master Library Blueprint</h3>
      
      {/* AI GENERATOR PANEL */}
      <div style={{ background: 'linear-gradient(135deg, #242424 0%, #1e133a 100%)', padding: '15px', borderRadius: '12px', marginBottom: '15px', border: '1px solid #4a2ba3', boxSizing: 'border-box' }}>
        <h4 style={{ margin: '0 0 10px 0', color: '#a335ee', fontSize: '0.9rem', display: 'flex', alignItems: 'center', gap: '6px' }}>
          🔮 AI Quest Forge (Gemini)
        </h4>
        <div style={{ display: 'flex', gap: '6px' }}>
          <input 
            placeholder="e.g., lose weight" 
            value={aiPrompt} 
            onChange={(e) => setAiPrompt(e.target.value)}
            disabled={isAiLoading}
            style={{ flex: 1, padding: '10px', background: '#000', color: 'white', border: '1px solid #444', borderRadius: '6px', fontSize: '0.85rem', boxSizing: 'border-box' }}
          />
          <button 
            onClick={generateAiQuest}
            disabled={isAiLoading}
            style={{ backgroundColor: '#f59e0b', color: 'white', border: 'none', padding: '0 15px', borderRadius: '6px', cursor: isAiLoading ? 'not-allowed' : 'pointer', fontWeight: 'bold', fontSize: '0.8rem', whiteSpace: 'nowrap' }}
          >
            {isAiLoading ? 'FORGING...' : 'FORGE'}
          </button>
        </div>
      </div>

      {/* MANUAL CREATION PANEL */}
      <details style={{ background: '#242424', padding: '15px', borderRadius: '12px', marginBottom: '25px', border: '1px solid #333', boxSizing: 'border-box' }}>
        <summary style={{ cursor: 'pointer', color: '#888', fontWeight: 'bold', fontSize: '0.85rem' }}>+ Create Manual Blueprint Template</summary>
        <input 
          placeholder="Quest Title..." value={title} onChange={(e) => setTitle(e.target.value)}
          style={{ width: '100%', padding: '10px', margin: '15px 0 10px 0', background: '#000', color: 'white', border: '1px solid #444', borderRadius: '4px', boxSizing: 'border-box' }}
        />
        <div style={{ display: 'flex', gap: '5px', alignItems: 'center' }}>
          
          {/* 🔧 The HTML value attribute now points to our rock-solid derived currentSelection */}
          <select 
            value={currentSelection} 
            onChange={(e) => setSelectedStat(e.target.value)} 
            style={{ flex: 1, padding: '8px', background: '#1a1a1a', color: 'white', border: '1px solid #444', borderRadius: '4px' }}
          >
            {stats.map(s => <option key={s.subject} value={s.subject}>{s.subject}</option>)}
          </select>
          
          <select value={rarity} onChange={(e) => setRarity(e.target.value)} style={{ flex: 1, padding: '8px', background: '#1a1a1a', color: 'white', border: '1px solid #444', borderRadius: '4px' }}>
            {Object.keys(rarityXpValues).map(tier => <option key={tier} value={tier}>{tier}</option>)}
          </select>

          <button onClick={addQuest} style={{ backgroundColor: '#222', color: 'white', border: '1px solid #444', padding: '8px 15px', borderRadius: '4px', cursor: 'pointer', fontWeight: 'bold' }}>ADD</button>
        </div>
      </details>

      {/* Accordion Layout */}
      {stats.map((s, idx) => {
        const isExpanded = expandedCategory === idx;
        const count = grouped[s.subject]?.length || 0;

        return (
          <div key={s.subject} style={{ border: '1px solid #333', borderRadius: '8px', marginBottom: '10px', overflow: 'hidden', backgroundColor: '#141414' }}>
            <div 
              onClick={() => setExpandedCategory(isExpanded ? -1 : idx)} 
              style={{ padding: '14px 18px', cursor: 'pointer', display: 'flex', justifyContent: 'space-between', alignItems: 'center', background: isExpanded ? '#1a1a1a' : 'transparent', userSelect: 'none' }}
            >
              <div>
                <span style={{ fontWeight: 'bold', color: isExpanded ? '#f59e0b' : 'white', fontSize: '0.95rem' }}>{s.subject}</span>
                <span style={{ fontSize: '0.75rem', color: '#666', marginLeft: '10px' }}>({count} blueprints)</span>
              </div>
              <span style={{ fontSize: '0.8rem', color: '#666' }}>{isExpanded ? '▼' : '►'}</span>
            </div>

            {isExpanded && (
              <div style={{ padding: '5px 18px 15px 18px', background: '#0e0e0e', borderTop: '1px solid #222' }}>
                {count === 0 ? (
                  <div style={{ fontSize: '0.8rem', color: '#444', padding: '15px 0 5px 0', fontStyle: 'italic' }}>No templates saved under this archetype...</div>
                ) : (
                  grouped[s.subject].map(q => (
                    <div key={q.id} style={{ display: 'flex', justifyContent: 'space-between', padding: '12px 0', borderBottom: '1px solid #222', fontSize: '0.9rem', alignItems: 'center' }}>
                      <div>
                        <span style={{ color: '#eee' }}>{q.title}</span>
                        <span style={{ fontSize: '0.65rem', marginLeft: '8px', fontWeight: 'bold', color: q.rarity === 'Epic' ? '#a335ee' : q.rarity === 'Rare' ? '#3b82f6' : q.rarity === 'Legendary' ? '#ff8000' : '#888' }}>
                          [{q.rarity.toUpperCase()}]
                        </span>
                      </div>
                      <div style={{ display: 'flex', gap: '8px', alignItems: 'center' }}>
                        {onShare && (
                          <button onClick={() => onShare(q)} style={{ background: 'transparent', border: 'none', color: '#43d9ad', cursor: 'pointer', fontSize: '0.8rem' }}>Share</button>
                        )}
                        <button onClick={() => deleteTemplate(q.id)} style={{ background: 'transparent', border: 'none', color: '#ff3e3e', cursor: 'pointer', fontSize: '0.8rem' }}>Delete</button>
                      </div>
                    </div>
                  ))
                )}
              </div>
            )}
          </div>
        );
      })}

      {/* --- PREVIEW REVIEW MODAL --- */}
      {showPreviewModal && (
        <div style={{ position: 'fixed', top: 0, left: 0, right: 0, bottom: 0, backgroundColor: 'rgba(0,0,0,0.85)', display: 'flex', justifyContent: 'center', alignItems: 'center', zIndex: 5000, padding: '20px' }}>
          <div style={{ backgroundColor: '#1c1c1e', padding: '25px', borderRadius: '16px', border: '1px solid #333', width: '100%', maxWidth: '400px', boxSizing: 'border-box' }}>
            <h3 style={{ margin: '0 0 5px 0', color: '#a335ee' }}>🔮 Review AI Blueprint</h3>
            <p style={{ fontSize: '0.75rem', color: '#888', margin: '0 0 20px 0' }}>Make adjustments to the parameters before storing.</p>
            
            <label style={{ fontSize: '0.75rem', fontWeight: 'bold', color: '#aaa', display: 'block', marginBottom: '5px' }}>QUEST TITLE</label>
            <input 
              value={previewTitle} 
              onChange={(e) => setPreviewTitle(e.target.value)}
              style={{ width: '100%', padding: '10px', background: '#000', color: '#fff', border: '1px solid #444', borderRadius: '6px', marginBottom: '15px', fontSize: '0.9rem', boxSizing: 'border-box' }}
            />

            <label style={{ fontSize: '0.75rem', fontWeight: 'bold', color: '#aaa', display: 'block', marginBottom: '5px' }}>ASSIGNED LIFE ATTRIBUTE</label>
            <select 
              value={previewStat} 
              onChange={(e) => setPreviewStat(e.target.value)}
              style={{ width: '100%', padding: '10px', background: '#000', color: '#fff', border: '1px solid #444', borderRadius: '6px', marginBottom: '15px', boxSizing: 'border-box' }}
            >
              {stats.map(s => <option key={s.subject} value={s.subject}>{s.subject}</option>)}
            </select>

            <label style={{ fontSize: '0.75rem', fontWeight: 'bold', color: '#aaa', display: 'block', marginBottom: '5px' }}>RARITY TIER</label>
            <select 
              value={previewRarity} 
              onChange={(e) => setPreviewRarity(e.target.value)}
              style={{ width: '100%', padding: '10px', background: '#000', color: '#fff', border: '1px solid #444', borderRadius: '6px', marginBottom: '25px', boxSizing: 'border-box' }}
            >
              {Object.keys(rarityXpValues).map(tier => <option key={tier} value={tier}>{tier}</option>)}
            </select>

            <div style={{ display: 'flex', gap: '10px' }}>
              <button 
                onClick={() => setShowPreviewModal(false)}
                style={{ flex: 1, padding: '12px', background: 'transparent', border: '1px solid #444', color: '#aaa', borderRadius: '8px', cursor: 'pointer', fontWeight: 'bold' }}
              >
                Discard
              </button>
              <button 
                onClick={commitPreviewQuest}
                style={{ flex: 1, padding: '12px', background: '#f59e0b', border: 'none', color: '#fff', borderRadius: '8px', cursor: 'pointer', fontWeight: 'bold' }}
              >
                Save Template
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}

function SettingsPage({ stats, setStats, questCapacity, setQuestCapacity, onSaveSettings, onCreateStat, onDeleteStat, onResetGlobalLevel }) {
  const [expanded, setExpanded] = useState(-1);
  const [newStatName, setNewStatName] = useState('');
  const totalWeight = stats.reduce((acc, s) => acc + s.weight, 0);
  const isMount = useRef(true);

  useEffect(() => {
    if (isMount.current) { isMount.current = false; return; }
    const t = setTimeout(() => onSaveSettings(), 600);
    return () => clearTimeout(t);
  }, [stats, questCapacity]);

  const updateStat = (index, field, value) => {
    const nextStats = stats.map((s, i) => {
      if (i === index) return { ...s, [field]: Number(value) };
      return s;
    });
    setStats(nextStats);
  };

  const addNewStat = async () => {
    const trimmedName = newStatName.trim();
    if (!trimmedName || stats.find(s => s.subject.toLowerCase() === trimmedName.toLowerCase())) return;

    try {
      const created = await onCreateStat(trimmedName);
      setStats([...stats, mapServerStat(created)]);
      setNewStatName('');
    } catch (error) {
      alert(error instanceof Error ? error.message : 'Failed to add new attribute.');
    }
  };

  const deleteStatClick = async (index) => {
    if (stats.length <= 3) return alert("Min 3 stats required!");

    const stat = stats[index];
    if (!stat?.id) return;

    const confirmed = window.confirm(
      `Delete "${stat.subject}"?\n\nThis will also permanently delete all quests in your library that are mapped to this attribute.`
    );
    if (!confirmed) return;

    try {
      await onDeleteStat(stat.id);
      setStats(stats.filter((_, i) => i !== index));
      setExpanded(-1);
    } catch (error) {
      alert(error instanceof Error ? error.message : 'Failed to delete attribute.');
    }
  };

  return (
    <div>
      <h3>System Tuning</h3>
      <div style={{ background: '#242424', padding: '15px', borderRadius: '12px', marginBottom: '20px', border: '1px solid #444', boxSizing: 'border-box' }}>
        <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: '10px' }}>
          <span>Daily Quest Slots</span>
          <span style={{ color: '#f59e0b', fontWeight: 'bold' }}>{questCapacity}</span>
        </div>
        <input type="range" min="1" max="10" value={questCapacity} onChange={(e) => setQuestCapacity(Number(e.target.value))} style={{ width: '100%' }} />
      </div>

      <h3>Add New Attribute</h3>
      <div style={{ display: 'flex', gap: '5px', marginBottom: '20px' }}>
        <input placeholder="New Stat..." value={newStatName} onChange={(e) => setNewStatName(e.target.value)} style={{ flex: 1, padding: '10px', background: '#1a1a1a', color: 'white', border: '1px solid #444', borderRadius: '4px', boxSizing: 'border-box' }} />
        <button onClick={addNewStat} style={{ backgroundColor: '#f59e0b', color: 'white', border: 'none', padding: '10px', cursor: 'pointer', borderRadius: '4px', fontWeight: 'bold' }}>CREATE</button>
      </div>

      <h3>Stat Weights & Levels</h3>
      {stats.map((s, i) => (
        <div key={s.subject} style={{ border: '1px solid #333', marginBottom: '8px', borderRadius: '8px', overflow: 'hidden' }}>
          <div onClick={() => setExpanded(expanded === i ? -1 : i)} style={{ padding: '12px', cursor: 'pointer', display: 'flex', justifyContent: 'space-between', background: expanded === i ? '#1a1a1a' : 'transparent', userSelect: 'none' }}>
            <div><span style={{ fontWeight: 'bold' }}>{s.subject}</span><div style={{ fontSize: '0.7rem', color: '#888' }}>Level {s.A}</div></div>
            <div style={{ color: '#f59e0b', fontSize: '0.8rem' }}>{totalWeight > 0 ? ((s.weight / totalWeight) * 100).toFixed(1) : 0}% Spawn</div>
          </div>
          {expanded === i && (
            <div style={{ padding: '15px', background: '#111', borderTop: '1px solid #333' }}>
              <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '4px' }}>
                <label style={{ fontSize: '0.7rem', color: '#888' }}>BASE LEVEL</label>
                <input
                  type="number"
                  min="0" max="100" step="1"
                  value={s.A}
                  onChange={(e) => {
                    const val = Math.min(100, Math.max(0, parseInt(e.target.value) || 0));
                    updateStat(i, 'A', val);
                  }}
                  style={{ width: '64px', padding: '3px 6px', background: '#1a1a1a', color: '#f59e0b', border: '1px solid #444', borderRadius: '4px', fontSize: '0.85rem', textAlign: 'center' }}
                />
              </div>
              <input type="range" min="0" max="100" value={s.A} onChange={(e) => updateStat(i, 'A', e.target.value)} style={{ width: '100%', marginBottom: '15px' }} />
              <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '4px' }}>
                <label style={{ fontSize: '0.7rem', color: '#888' }}>SPAWN WEIGHT</label>
                <input
                  type="number"
                  min="0" max="5" step="0.1"
                  value={s.weight}
                  onChange={(e) => {
                    const val = Math.min(5, Math.max(0, parseFloat(e.target.value) || 0));
                    updateStat(i, 'weight', val);
                  }}
                  style={{ width: '64px', padding: '3px 6px', background: '#1a1a1a', color: '#f59e0b', border: '1px solid #444', borderRadius: '4px', fontSize: '0.85rem', textAlign: 'center' }}
                />
              </div>
              <input type="range" min="0" max="5" step="0.1" value={s.weight} onChange={(e) => updateStat(i, 'weight', e.target.value)} style={{ width: '100%' }} />
              <button onClick={() => deleteStatClick(i)} style={{ marginTop: '15px', width: '100%', padding: '8px', border: '1px solid #ff3e3e', color: '#ff3e3e', background: 'transparent', cursor: 'pointer', borderRadius: '6px' }}>DELETE</button>
            </div>
          )}
        </div>
      ))}

      <button onClick={onResetGlobalLevel} style={{ marginTop: '10px', width: '100%', padding: '10px', backgroundColor: '#222', color: '#ffb86b', border: '1px solid #444', borderRadius: '8px', cursor: 'pointer' }}>
        Reset Global Level to 1
      </button>
    </div>
  );
}

function ProfilePage({ currentUser, setCurrentUser, authFetch, masterQuestPool, setMasterQuestPool }) {
  const [tab, setTab] = useState('friends');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [isRegistering, setIsRegistering] = useState(false);
  const [friends, setFriends] = useState([]);
  const [requests, setRequests] = useState([]);
  const [inbox, setInbox] = useState([]);
  const [addFriendInput, setAddFriendInput] = useState('');
  const [isBusy, setIsBusy] = useState(false);

  const profileFetch = (endpoint, options = {}) =>
    apiFetch(endpoint, {
      ...options,
      headers: { 'Content-Type': 'application/json', 'X-User-Id': String(currentUser?.id || 0), ...(options.headers || {}) },
    });

  const loadFriends = async () => {
    try {
      const [f, r] = await Promise.all([
        profileFetch('/api/friends'),
        profileFetch('/api/friends/requests'),
      ]);
      setFriends(f);
      setRequests(r);
    } catch (e) { alert(e.message); }
  };

  const loadInbox = async () => {
    try { setInbox(await profileFetch('/api/inbox')); }
    catch (e) { alert(e.message); }
  };

  useEffect(() => {
    if (!currentUser) return;
    loadFriends();
    loadInbox();
  }, [currentUser]);

  const handleAuth = async () => {
    if (!username.trim() || !password.trim()) return alert('Fill in both fields.');
    setIsBusy(true);
    try {
      const endpoint = isRegistering ? '/api/auth/register' : '/api/auth/login';
      const user = await apiFetch(endpoint, { method: 'POST', body: JSON.stringify({ username: username.trim(), password }) });
      setCurrentUser(user);
      setUsername('');
      setPassword('');
    } catch (e) {
      alert(e instanceof Error ? e.message : 'Auth failed.');
    } finally {
      setIsBusy(false);
    }
  };

  const handleSendRequest = async () => {
    if (!addFriendInput.trim()) return;
    try {
      const result = await profileFetch(`/api/friends/${encodeURIComponent(addFriendInput.trim())}`, { method: 'POST' });
      alert(result.message);
      setAddFriendInput('');
    } catch (e) {
      alert(e instanceof Error ? e.message : 'Could not send request.');
    }
  };

  const handleAccept = async (req) => {
    try {
      const friend = await profileFetch(`/api/friends/${req.id}/accept`, { method: 'POST' });
      setRequests(prev => prev.filter(r => r.id !== req.id));
      setFriends(prev => [...prev, friend]);
    } catch (e) {
      alert(e instanceof Error ? e.message : 'Could not accept request.');
    }
  };

  const handleReject = async (req) => {
    try {
      await profileFetch(`/api/friends/${req.id}/reject`, { method: 'POST' });
      setRequests(prev => prev.filter(r => r.id !== req.id));
    } catch (e) {
      alert(e instanceof Error ? e.message : 'Could not reject request.');
    }
  };

  const handleRemoveFriend = async (friendId) => {
    try {
      await profileFetch(`/api/friends/${friendId}`, { method: 'DELETE' });
      setFriends(prev => prev.filter(f => f.id !== friendId));
    } catch (e) {
      alert(e instanceof Error ? e.message : 'Could not remove friend.');
    }
  };

  const handleAddToLibrary = async (item) => {
    try {
      const created = await profileFetch(`/api/inbox/${item.id}/add-to-library`, { method: 'POST' });
      setMasterQuestPool(prev => [...prev, { id: created.id, title: created.title, stat: created.stat, rarity: created.rarity, xpReward: created.xpReward }]);
      setInbox(prev => prev.map(i => i.id === item.id ? { ...i, isRead: true } : i));
      alert(`"${item.title}" added to your library!`);
    } catch (e) {
      alert(e instanceof Error ? e.message : 'Failed to add to library.');
    }
  };

  const handleDismiss = async (itemId) => {
    try {
      await profileFetch(`/api/inbox/${itemId}`, { method: 'DELETE' });
      setInbox(prev => prev.filter(i => i.id !== itemId));
    } catch (e) {
      alert(e instanceof Error ? e.message : 'Failed to dismiss.');
    }
  };

  const rarityColor = { Common: '#888', Rare: '#3b82f6', Epic: '#a335ee', Legendary: '#ff8000' };

  const formatDate = (iso) => {
    if (!iso) return null;
    return new Date(iso).toLocaleDateString(undefined, { month: 'short', day: 'numeric', year: 'numeric' });
  };

  if (!currentUser) {
    return (
      <div>
        <h3>{isRegistering ? 'Create Account' : 'Login'}</h3>
        <input
          placeholder="Username"
          value={username}
          onChange={e => setUsername(e.target.value)}
          style={{ width: '100%', padding: '10px', background: '#1a1a1a', color: 'white', border: '1px solid #444', borderRadius: '6px', marginBottom: '10px', boxSizing: 'border-box' }}
        />
        <input
          type="password"
          placeholder="Password"
          value={password}
          onChange={e => setPassword(e.target.value)}
          onKeyDown={e => e.key === 'Enter' && handleAuth()}
          style={{ width: '100%', padding: '10px', background: '#1a1a1a', color: 'white', border: '1px solid #444', borderRadius: '6px', marginBottom: '15px', boxSizing: 'border-box' }}
        />
        <button
          onClick={handleAuth}
          disabled={isBusy}
          style={{ width: '100%', padding: '12px', backgroundColor: '#f59e0b', color: 'white', border: 'none', borderRadius: '8px', cursor: 'pointer', fontWeight: 'bold', marginBottom: '10px' }}
        >
          {isBusy ? '...' : isRegistering ? 'Register' : 'Login'}
        </button>
        <button
          onClick={() => setIsRegistering(r => !r)}
          style={{ width: '100%', padding: '10px', background: 'transparent', border: '1px solid #333', color: '#888', borderRadius: '8px', cursor: 'pointer', fontSize: '0.85rem' }}
        >
          {isRegistering ? 'Already have an account? Login' : "Don't have an account? Register"}
        </button>
      </div>
    );
  }

  const unreadCount = inbox.filter(i => !i.isRead).length;

  return (
    <div>
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '20px' }}>
        <div>
          <h3 style={{ margin: 0 }}>{currentUser.username}</h3>
          <span style={{ fontSize: '0.75rem', color: '#666' }}>Life Optimizer Profile</span>
        </div>
        <button
          onClick={() => setCurrentUser(null)}
          style={{ background: 'transparent', border: '1px solid #444', color: '#888', padding: '6px 12px', borderRadius: '6px', cursor: 'pointer', fontSize: '0.8rem' }}
        >
          Logout
        </button>
      </div>

      <div style={{ display: 'flex', gap: '8px', marginBottom: '20px' }}>
        <button
          onClick={() => setTab('friends')}
          style={{ flex: 1, padding: '8px', background: tab === 'friends' ? '#f59e0b' : 'transparent', border: '1px solid #f59e0b', color: tab === 'friends' ? '#fff' : '#f59e0b', borderRadius: '6px', cursor: 'pointer', fontWeight: 'bold', fontSize: '0.8rem' }}
        >
          Friends ({friends.length}){requests.length > 0 ? ` · ${requests.length} req` : ''}
        </button>
        <button
          onClick={() => setTab('inbox')}
          style={{ flex: 1, padding: '8px', background: tab === 'inbox' ? '#f59e0b' : 'transparent', border: '1px solid #f59e0b', color: tab === 'inbox' ? '#fff' : '#f59e0b', borderRadius: '6px', cursor: 'pointer', fontWeight: 'bold', fontSize: '0.8rem' }}
        >
          Inbox {unreadCount > 0 ? `(${unreadCount} new)` : `(${inbox.length})`}
        </button>
      </div>

      {tab === 'friends' && (
        <div>
          <div style={{ display: 'flex', gap: '8px', marginBottom: '20px' }}>
            <input
              placeholder="Send request by username..."
              value={addFriendInput}
              onChange={e => setAddFriendInput(e.target.value)}
              onKeyDown={e => e.key === 'Enter' && handleSendRequest()}
              style={{ flex: 1, padding: '10px', background: '#1a1a1a', color: 'white', border: '1px solid #444', borderRadius: '6px', boxSizing: 'border-box' }}
            />
            <button
              onClick={handleSendRequest}
              style={{ padding: '10px 16px', backgroundColor: '#f59e0b', color: 'white', border: 'none', borderRadius: '6px', cursor: 'pointer', fontWeight: 'bold' }}
            >
              Add
            </button>
          </div>

          {requests.length > 0 && (
            <div style={{ marginBottom: '20px' }}>
              <p style={{ fontSize: '0.75rem', color: '#f9c74f', fontWeight: 'bold', margin: '0 0 10px 0', textTransform: 'uppercase', letterSpacing: '1px' }}>Pending Requests</p>
              {requests.map(req => (
                <div key={req.id} style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', padding: '12px', border: '1px solid #3a3010', borderRadius: '8px', marginBottom: '8px', backgroundColor: '#1a1500' }}>
                  <span style={{ fontWeight: 'bold' }}>{req.fromUsername}</span>
                  <div style={{ display: 'flex', gap: '8px' }}>
                    <button
                      onClick={() => handleAccept(req)}
                      style={{ padding: '6px 12px', background: '#43d9ad', border: 'none', color: '#000', borderRadius: '6px', cursor: 'pointer', fontWeight: 'bold', fontSize: '0.8rem' }}
                    >
                      Accept
                    </button>
                    <button
                      onClick={() => handleReject(req)}
                      style={{ padding: '6px 12px', background: 'transparent', border: '1px solid #ff3e3e', color: '#ff3e3e', borderRadius: '6px', cursor: 'pointer', fontSize: '0.8rem' }}
                    >
                      Reject
                    </button>
                  </div>
                </div>
              ))}
            </div>
          )}

          {friends.length === 0 ? (
            <p style={{ color: '#444', fontSize: '0.85rem', textAlign: 'center', padding: '20px', border: '1px dashed #333', borderRadius: '8px' }}>
              No friends yet. Send a request above!
            </p>
          ) : (
            friends.map(f => (
              <div key={f.id} style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', padding: '12px', border: '1px solid #222', borderRadius: '8px', marginBottom: '8px' }}>
                <div>
                  <div style={{ fontWeight: 'bold' }}>{f.username}</div>
                  {f.addedAt && <div style={{ fontSize: '0.7rem', color: '#555', marginTop: '2px' }}>Added {formatDate(f.addedAt)}</div>}
                </div>
                <button
                  onClick={() => handleRemoveFriend(f.id)}
                  style={{ background: 'transparent', border: 'none', color: '#ff3e3e', cursor: 'pointer', fontSize: '0.8rem' }}
                >
                  Remove
                </button>
              </div>
            ))
          )}
        </div>
      )}

      {tab === 'inbox' && (
        <div>
          {inbox.length === 0 ? (
            <p style={{ color: '#444', fontSize: '0.85rem', textAlign: 'center', padding: '20px', border: '1px dashed #333', borderRadius: '8px' }}>
              Inbox is empty.
            </p>
          ) : (
            inbox.map(item => (
              <div key={item.id} style={{ border: `1px solid ${item.isRead ? '#222' : '#f59e0b'}`, borderRadius: '10px', padding: '14px', marginBottom: '10px', backgroundColor: item.isRead ? '#111' : '#141000' }}>
                <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: '4px' }}>
                  <span style={{ fontSize: '0.7rem', color: '#666' }}>from {item.senderUsername}</span>
                  <span style={{ fontSize: '0.65rem', fontWeight: 'bold', color: rarityColor[item.rarity] || '#888' }}>{item.rarity?.toUpperCase()}</span>
                </div>
                <div style={{ fontWeight: 'bold', marginBottom: '6px' }}>{item.title}</div>
                <div style={{ fontSize: '0.75rem', color: '#888', marginBottom: '12px' }}>Boosts: {item.stat} · +{item.xpReward} XP</div>
                <div style={{ display: 'flex', gap: '8px' }}>
                  <button
                    onClick={() => handleAddToLibrary(item)}
                    style={{ flex: 1, padding: '8px', background: '#f59e0b', border: 'none', color: '#fff', borderRadius: '6px', cursor: 'pointer', fontWeight: 'bold', fontSize: '0.8rem' }}
                  >
                    Add to Library
                  </button>
                  <button
                    onClick={() => handleDismiss(item.id)}
                    style={{ padding: '8px 12px', background: 'transparent', border: '1px solid #333', color: '#666', borderRadius: '6px', cursor: 'pointer', fontSize: '0.8rem' }}
                  >
                    Dismiss
                  </button>
                </div>
              </div>
            ))
          )}
        </div>
      )}
    </div>
  );
}

export default App;