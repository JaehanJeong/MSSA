import { useState, useEffect } from 'react';
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

const DEFAULT_QUESTS = [
  { id: 1, title: "Read 10 pages of educational material", stat: "Intelligence", rarity: "Common", xpReward: 10 },
  { id: 2, title: "Complete a 30-minute workout session", stat: "Health", rarity: "Rare", xpReward: 25 },
  { id: 3, title: "Review monthly budget and savings goals", stat: "Wealth", rarity: "Epic", xpReward: 75 },
];

// 🔧 Explicitly pointing to your .NET backend server port
const BACKEND_BASE_URL = 'http://localhost:5248';

const apiFetch = async (endpoint, options = {}) => {
  const fullUrl = `${BACKEND_BASE_URL}${endpoint}`;
  
  const response = await fetch(fullUrl, {
    headers: { 'Content-Type': 'application/json' },
    ...options,
  });

  if (!response.ok) {
    const errorText = await response.text();
    const message = `API request failed: ${fullUrl} (Status ${response.status}). Ensure backend is running on the correct port.`;
    console.error(`[API ERROR]`, { fullUrl, status: response.status, body: errorText });
    throw new Error(errorText || message);
  }

  const text = await response.text();
  if (!text) {
    return null;
  }

  return JSON.parse(text);
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
  const [masterQuestPool, setMasterQuestPool] = useState(DEFAULT_QUESTS);
  const [activeDailyQuests, setActiveDailyQuests] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [errorMessage, setErrorMessage] = useState('');

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

        await refreshProfile();
        await Promise.all([refreshQuestTemplates(), refreshActiveDailyQuests()]);
      } catch (error) {
        setErrorMessage(error instanceof Error ? error.message : 'Failed to load app data.');
      } finally {
        setIsLoading(false);
      }
    };

    loadAll();
  }, []);

  const generateDailyQuests = async () => {
    if (masterQuestPool.length === 0) return alert("Your Blueprint Library is empty!");

    try {
      await apiFetch('/api/activequests/roll', {
        method: 'POST',
        body: JSON.stringify({ count: questCapacity }),
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

  const saveSettings = async () => {
    try {
      await apiFetch('/api/profile', {
        method: 'PUT',
        body: JSON.stringify({
          questCapacity,
          stats: stats.map((s) => ({ id: s.id, level: s.A, weight: s.weight })),
        }),
      });
      await refreshProfile();
      alert('Settings saved.');
    } catch (error) {
      alert(error instanceof Error ? error.message : 'Failed to save settings.');
    }
  };

  const createStat = async (subject) => {
    return apiFetch('/api/stats', {
      method: 'POST',
      body: JSON.stringify({ subject, level: 10, weight: 1.0 }),
    });
  };

  const deleteStat = async (statId) => {
    await apiFetch(`/api/stats/${statId}`, { method: 'DELETE' });
  };

  return (
    <div style={{ padding: '20px', maxWidth: '500px', margin: '0 auto', paddingBottom: '80px', color: 'white', minHeight: '100vh', backgroundColor: '#0f0f0f', boxSizing: 'border-box' }}>
      
      <header style={{ marginBottom: '20px', textAlign: 'center' }}>
        <h1 style={{ color: '#646cff', letterSpacing: '2px', margin: '0 0 5px 0' }}>LIFE OPTIMIZER</h1>
        <div style={{ display: 'flex', justifyContent: 'space-between', fontSize: '0.85rem', color: '#888', maxWidth: '300px', margin: '0 auto' }}>
          <span>GLOBAL LEVEL <strong style={{ color: '#646cff' }}>{globalLevel}</strong></span>
          <span>{globalXp} / {xpNeededForLevelUp} XP</span>
        </div>
        <div style={{ width: '100%', maxWidth: '300px', height: '6px', backgroundColor: '#222', borderRadius: '3px', margin: '6px auto 0 auto', overflow: 'hidden' }}>
          <div style={{ width: `${(globalXp / xpNeededForLevelUp) * 100}%`, height: '100%', backgroundColor: '#646cff', transition: 'width 0.3s ease' }} />
        </div>
      </header>

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
                    style={{ background: 'transparent', border: '1px solid #646cff', color: '#646cff', padding: '6px 12px', borderRadius: '20px', fontSize: '0.75rem', fontWeight: 'bold', cursor: 'pointer' }}
                  >
                    🎲 Roll Daily Quests
                  </button>
                </div>

                {activeDailyQuests.length === 0 ? (
                  <p style={{ color: '#444', fontSize: '0.85rem', textAlign: 'center', padding: '20px', border: '1px dashed #333', borderRadius: '8px' }}>
                    No assignments loaded. Click "Roll Daily Quests" to populate active trackers ({questCapacity} slots max).
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
                    />
                  ))
                )}
              </div>
            </div>
          } />
          
          <Route path="/quests" element={
            <QuestPage 
              stats={stats} 
              masterQuestPool={masterQuestPool} 
              setMasterQuestPool={setMasterQuestPool} 
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
            />
          } />
        </Routes>
      </main>

      <nav style={{
        position: 'fixed', bottom: 0, left: 0, right: 0,
        backgroundColor: '#1a1a1a', display: 'flex',
        justifyContent: 'space-around', padding: '15px', borderTop: '1px solid #444', zIndex: 1000
      }}>
        <Link to="/" style={{ color: location.pathname === '/' ? '#646cff' : '#888', textDecoration: 'none', fontWeight: 'bold', fontSize: '0.8rem' }}>STATS</Link>
        <Link to="/quests" style={{ color: location.pathname === '/quests' ? '#646cff' : '#888', textDecoration: 'none', fontWeight: 'bold', fontSize: '0.8rem' }}>LIBRARY</Link>
        <Link to="/settings" style={{ color: location.pathname === '/settings' ? '#646cff' : '#888', textDecoration: 'none', fontWeight: 'bold', fontSize: '0.8rem' }}>TUNING</Link>
      </nav>
    </div>
  );
}

function QuestPage({ stats, masterQuestPool, setMasterQuestPool }) {
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
      console.error(error);
      alert(error instanceof Error ? error.message : 'Failed to synthesize quest card.');
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
    try {
      await apiFetch(`/api/questtemplates/${id}`, { method: 'DELETE' });
      setMasterQuestPool(masterQuestPool.filter(q => q.id !== id));
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
            placeholder="Type a real-life goal (e.g., wash dishes, run 5k)..." 
            value={aiPrompt} 
            onChange={(e) => setAiPrompt(e.target.value)}
            disabled={isAiLoading}
            style={{ flex: 1, padding: '10px', background: '#000', color: 'white', border: '1px solid #444', borderRadius: '6px', fontSize: '0.85rem', boxSizing: 'border-box' }}
          />
          <button 
            onClick={generateAiQuest}
            disabled={isAiLoading}
            style={{ backgroundColor: '#646cff', color: 'white', border: 'none', padding: '0 15px', borderRadius: '6px', cursor: isAiLoading ? 'not-allowed' : 'pointer', fontWeight: 'bold', fontSize: '0.8rem', whiteSpace: 'nowrap' }}
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
                <span style={{ fontWeight: 'bold', color: isExpanded ? '#646cff' : 'white', fontSize: '0.95rem' }}>{s.subject}</span>
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
                        <span style={{ fontSize: '0.65rem', marginLeft: '8px', fontWeight: 'bold', color: q.rarity === 'Epic' ? '#a335ee' : q.rarity === 'Rare' ? '#646cff' : q.rarity === 'Legendary' ? '#ff8000' : '#888' }}>
                          [{q.rarity.toUpperCase()}]
                        </span>
                      </div>
                      <button onClick={() => deleteTemplate(q.id)} style={{ background: 'transparent', border: 'none', color: '#ff3e3e', cursor: 'pointer', fontSize: '0.8rem' }}>Delete</button>
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
                style={{ flex: 1, padding: '12px', background: '#646cff', border: 'none', color: '#fff', borderRadius: '8px', cursor: 'pointer', fontWeight: 'bold' }}
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

function SettingsPage({ stats, setStats, questCapacity, setQuestCapacity, onSaveSettings, onCreateStat, onDeleteStat }) {
  const [expanded, setExpanded] = useState(-1);
  const [newStatName, setNewStatName] = useState('');
  const totalWeight = stats.reduce((acc, s) => acc + s.weight, 0);

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
          <span style={{ color: '#646cff', fontWeight: 'bold' }}>{questCapacity}</span>
        </div>
        <input type="range" min="1" max="10" value={questCapacity} onChange={(e) => setQuestCapacity(Number(e.target.value))} style={{ width: '100%' }} />
      </div>

      <h3>Add New Attribute</h3>
      <div style={{ display: 'flex', gap: '5px', marginBottom: '20px' }}>
        <input placeholder="New Stat..." value={newStatName} onChange={(e) => setNewStatName(e.target.value)} style={{ flex: 1, padding: '10px', background: '#1a1a1a', color: 'white', border: '1px solid #444', borderRadius: '4px', boxSizing: 'border-box' }} />
        <button onClick={addNewStat} style={{ backgroundColor: '#646cff', color: 'white', border: 'none', padding: '10px', cursor: 'pointer', borderRadius: '4px', fontWeight: 'bold' }}>CREATE</button>
      </div>

      <h3>Stat Weights & Levels</h3>
      {stats.map((s, i) => (
        <div key={s.subject} style={{ border: '1px solid #333', marginBottom: '8px', borderRadius: '8px', overflow: 'hidden' }}>
          <div onClick={() => setExpanded(expanded === i ? -1 : i)} style={{ padding: '12px', cursor: 'pointer', display: 'flex', justifyContent: 'space-between', background: expanded === i ? '#1a1a1a' : 'transparent', userSelect: 'none' }}>
            <div><span style={{ fontWeight: 'bold' }}>{s.subject}</span><div style={{ fontSize: '0.7rem', color: '#888' }}>Level {s.A}</div></div>
            <div style={{ color: '#646cff', fontSize: '0.8rem' }}>{totalWeight > 0 ? ((s.weight / totalWeight) * 100).toFixed(1) : 0}% Spawn</div>
          </div>
          {expanded === i && (
            <div style={{ padding: '15px', background: '#111', borderTop: '1px solid #333' }}>
              <label style={{ fontSize: '0.7rem', color: '#888' }}>BASE LEVEL ({s.A})</label>
              <input type="range" min="0" max="100" value={s.A} onChange={(e) => updateStat(i, 'A', e.target.value)} style={{ width: '100%', marginBottom: '15px' }} />
              <label style={{ fontSize: '0.7rem', color: '#888' }}>SPAWN WEIGHT</label>
              <input type="range" min="0.1" max="5" step="0.1" value={s.weight} onChange={(e) => updateStat(i, 'weight', e.target.value)} style={{ width: '100%' }} />
              <button onClick={() => deleteStatClick(i)} style={{ marginTop: '15px', width: '100%', padding: '8px', border: '1px solid #ff3e3e', color: '#ff3e3e', background: 'transparent', cursor: 'pointer', borderRadius: '6px' }}>DELETE</button>
            </div>
          )}
        </div>
      ))}

      <button onClick={onSaveSettings} style={{ marginTop: '15px', width: '100%', padding: '12px', backgroundColor: '#646cff', color: 'white', border: 'none', borderRadius: '8px', cursor: 'pointer', fontWeight: 'bold' }}>
        SAVE SETTINGS
      </button>
    </div>
  );
}

export default App;