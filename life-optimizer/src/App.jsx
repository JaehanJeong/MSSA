import { useState, useEffect } from 'react';
import { Routes, Route, Link, useLocation } from 'react-router-dom';
import { GoogleGenAI } from '@google/genai'; 
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

function App() {
  const location = useLocation();
  const xpNeededForLevelUp = 100;

  const [globalXp, setGlobalXp] = useState(() => Number(localStorage.getItem('lo_globalXp')) || 0);
  const [globalLevel, setGlobalLevel] = useState(() => Number(localStorage.getItem('lo_globalLevel')) || 1);
  const [questCapacity, setQuestCapacity] = useState(() => Number(localStorage.getItem('lo_questCapacity')) || 3);
  
  const [stats, setStats] = useState(() => {
    const saved = localStorage.getItem('lo_stats');
    if (saved !== null) {
      const parsed = JSON.parse(saved);
      if (parsed.some(s => s.subject === 'Focus' || s.subject === 'Violin')) return DEFAULT_STATS;
      return parsed;
    }
    return DEFAULT_STATS;
  });

  const [masterQuestPool, setMasterQuestPool] = useState(() => {
    const saved = localStorage.getItem('lo_masterQuestPool');
    if (saved !== null) {
      const parsed = JSON.parse(saved);
      if (parsed.some(q => q.stat === 'Focus' || q.stat === 'Violin')) return DEFAULT_QUESTS;
      return parsed;
    }
    return DEFAULT_QUESTS;
  });

  const [activeDailyQuests, setActiveDailyQuests] = useState(() => JSON.parse(localStorage.getItem('lo_activeDailyQuests')) || []);

  useEffect(() => {
    localStorage.setItem('lo_globalXp', globalXp);
    localStorage.setItem('lo_globalLevel', globalLevel);
    localStorage.setItem('lo_stats', JSON.stringify(stats));
    localStorage.setItem('lo_questCapacity', questCapacity);
    localStorage.setItem('lo_masterQuestPool', JSON.stringify(masterQuestPool));
    localStorage.setItem('lo_activeDailyQuests', JSON.stringify(activeDailyQuests));
  }, [globalXp, globalLevel, stats, questCapacity, masterQuestPool, activeDailyQuests]);

  const generateDailyQuests = () => {
    if (masterQuestPool.length === 0) return alert("Your Blueprint Library is empty!");
    
    const shuffled = [...masterQuestPool].sort(() => 0.5 - Math.random());
    const selected = shuffled.slice(0, questCapacity).map(quest => ({
      ...quest,
      id: `active-${Date.now()}-${Math.random()}` 
    }));

    setActiveDailyQuests(selected);
  };

  // --- FIXED PROGRESSION ENGINE: HANDLES EXPLOSIVE XP SURGES ---
  const processQuestCompletion = (activeQuestId, statName, xpAwarded) => {
    setActiveDailyQuests((prev) => prev.filter(q => q.id !== activeQuestId));

    setStats((prevStats) =>
      prevStats.map((s) => {
        if (s.subject === statName) {
          return { ...s, A: Math.min(parseFloat((s.A + 0.5).toFixed(2)), 100) };
        }
        return s;
      })
    );

    setGlobalXp((prevXp) => {
      let currentXp = prevXp + xpAwarded;
      let currentLevel = globalLevel;
      let levelsGained = 0;

      // Safe loop engine to crunch out multiple level ups at once
      while (currentXp >= xpNeededForLevelUp) {
        currentXp -= xpNeededForLevelUp;
        currentLevel += 1;
        levelsGained += 1;
      }

      if (levelsGained > 0) {
        setGlobalLevel(currentLevel);
        
        if (levelsGained === 1) {
          alert(`🎉 LEVEL UP! You reached Global Level ${currentLevel}!`);
        } else {
          alert(`🔥 MULTI-LEVEL Surge! You gained +${levelsGained} levels at once and reached Level ${currentLevel}!`);
        }
      }

      return currentXp; 
    });
  };

  return (
    <div style={{ padding: '20px', maxWidth: '500px', margin: '0 auto', paddingBottom: '80px', color: 'white', minHeight: '100vh', backgroundColor: '#0f0f0f' }}>
      
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
                      onComplete={() => processQuestCompletion(q.id, q.stat, q.xpReward)}
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
  const [selectedStat, setSelectedStat] = useState(stats[0]?.subject || '');
  const [rarity, setRarity] = useState('Common');
  const [expandedCategory, setExpandedCategory] = useState(-1);
  
  const [aiPrompt, setAiPrompt] = useState('');
  const [isAiLoading, setIsAiLoading] = useState(false);

  const [showPreviewModal, setShowPreviewModal] = useState(false);
  const [previewTitle, setPreviewTitle] = useState('');
  const [previewStat, setPreviewStat] = useState('');
  const [previewRarity, setPreviewRarity] = useState('Common');

  const rarityXpValues = { Common: 10, Rare: 25, Epic: 50, Legendary: 100 };

  useEffect(() => {
    if (stats.length > 0 && !stats.find(s => s.subject === selectedStat)) {
      setSelectedStat(stats[0].subject);
    }
  }, [stats]);

  const addQuest = () => {
    if (!title) return;
    setMasterQuestPool([...masterQuestPool, { 
      id: Date.now(), 
      title, 
      stat: selectedStat, 
      rarity,
      xpReward: rarityXpValues[rarity]
    }]);
    setTitle('');
  };

  const generateAiQuest = async () => {
    if (!aiPrompt.trim()) return alert("Enter a real-world concept or task first!");
    
    const apiKey = import.meta.env.VITE_GEMINI_API_KEY;
    if (!apiKey) return alert("Missing VITE_GEMINI_API_KEY env variable.");

    setIsAiLoading(true);
    try {
      const ai = new GoogleGenAI({ apiKey });
      const availableAttributes = stats.map(s => s.subject).join(', ');

      const response = await ai.models.generateContent({
        model: 'gemini-2.5-flash',
        contents: `You are an expert game designer running an RPG real-life simulator. 
        Turn this real-world task or goal into an epic RPG quest template: "${aiPrompt}".
        You must pick the most logical matching life attribute from this list: [${availableAttributes}].
        You must assign an appropriate rarity from this list: [Common, Rare, Epic, Legendary].
        Return strictly JSON matching this structure:
        { "title": "Title String", "stat": "Attribute String", "rarity": "Rarity String" }`,
        config: { responseMimeType: "application/json" }
      });

      const resultData = JSON.parse(response.text);
      
      setPreviewTitle(resultData.title);
      setPreviewStat(stats.find(s => s.subject === resultData.stat) ? resultData.stat : stats[0].subject);
      setPreviewRarity(rarityXpValues[resultData.rarity] ? resultData.rarity : 'Common');
      
      setIsAiLoading(false);
      setShowPreviewModal(true); 

    } catch (error) {
      console.error(error);
      alert("Failed to synthesize quest card.");
      setIsAiLoading(false);
    }
  };

  const commitPreviewQuest = () => {
    if (!previewTitle.trim()) return alert("Title can't be blank!");
    
    setMasterQuestPool(prevPool => [
      ...prevPool,
      {
        id: Date.now(),
        title: previewTitle,
        stat: previewStat,
        rarity: previewRarity,
        xpReward: rarityXpValues[previewRarity]
      }
    ]);

    setShowPreviewModal(false);
    setAiPrompt('');
  };

  const deleteTemplate = (id) => {
    setMasterQuestPool(masterQuestPool.filter(q => q.id !== id));
  };

  const grouped = stats.reduce((acc, s) => {
    acc[s.subject] = masterQuestPool.filter(q => q.stat === s.subject);
    return acc;
  }, {});

  return (
    <div>
      <h3>Master Library Blueprint</h3>
      
      {/* AI GENERATOR PANEL */}
      <div style={{ background: 'linear-gradient(135deg, #242424 0%, #1e133a 100%)', padding: '15px', borderRadius: '12px', marginBottom: '15px', border: '1px solid #4a2ba3' }}>
        <h4 style={{ margin: '0 0 10px 0', color: '#a335ee', fontSize: '0.9rem', display: 'flex', alignItems: 'center', gap: '6px' }}>
          🔮 AI Quest Forge (Gemini)
        </h4>
        <div style={{ display: 'flex', gap: '6px' }}>
          <input 
            placeholder="Type a real-life goal (e.g., wash dishes, run 5k)..." 
            value={aiPrompt} 
            onChange={(e) => setAiPrompt(e.target.value)}
            disabled={isAiLoading}
            style={{ flex: 1, padding: '10px', background: '#000', color: 'white', border: '1px solid #444', borderRadius: '6px', fontSize: '0.85rem' }}
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
      <details style={{ background: '#242424', padding: '15px', borderRadius: '12px', marginBottom: '25px', border: '1px solid #333' }}>
        <summary style={{ cursor: 'pointer', color: '#888', fontWeight: 'bold', fontSize: '0.85rem' }}>+ Create Manual Blueprint Template</summary>
        <input 
          placeholder="Quest Title..." value={title} onChange={(e) => setTitle(e.target.value)}
          style={{ width: '95%', padding: '10px', margin: '15px 0 10px 0', background: '#000', color: 'white', border: '1px solid #444', borderRadius: '4px' }}
        />
        <div style={{ display: 'flex', gap: '5px', alignItems: 'center' }}>
          <select value={selectedStat} onChange={(e) => setSelectedStat(e.target.value)} style={{ flex: 1, padding: '8px' }}>
            {stats.map(s => <option key={s.subject}>{s.subject}</option>)}
          </select>
          
          <select value={rarity} onChange={(e) => setRarity(e.target.value)} style={{ flex: 1, padding: '8px', background: '#1a1a1a', color: 'white' }}>
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
          <div style={{ backgroundColor: '#1c1c1e', padding: '25px', borderRadius: '16px', border: '1px solid #333', width: '100%', maxWidth: '400px' }}>
            <h3 style={{ margin: '0 0 5px 0', color: '#a335ee' }}>🔮 Review AI Blueprint</h3>
            <p style={{ fontSize: '0.75rem', color: '#888', margin: '0 0 20px 0' }}>Make adjustments to the parameters before storing.</p>
            
            <label style={{ fontSize: '0.75rem', fontWeight: 'bold', color: '#aaa', display: 'block', marginBottom: '5px' }}>QUEST TITLE</label>
            <input 
              value={previewTitle} 
              onChange={(e) => setPreviewTitle(e.target.value)}
              style={{ width: '94%', padding: '10px', background: '#000', color: '#fff', border: '1px solid #444', borderRadius: '6px', marginBottom: '15px', fontSize: '0.9rem' }}
            />

            <label style={{ fontSize: '0.75rem', fontWeight: 'bold', color: '#aaa', display: 'block', marginBottom: '5px' }}>ASSIGNED LIFE ATTRIBUTE</label>
            <select 
              value={previewStat} 
              onChange={(e) => setPreviewStat(e.target.value)}
              style={{ width: '100%', padding: '10px', background: '#000', color: '#fff', border: '1px solid #444', borderRadius: '6px', marginBottom: '15px' }}
            >
              {stats.map(s => <option key={s.subject} value={s.subject}>{s.subject}</option>)}
            </select>

            <label style={{ fontSize: '0.75rem', fontWeight: 'bold', color: '#aaa', display: 'block', marginBottom: '5px' }}>RARITY TIER</label>
            <select 
              value={previewRarity} 
              onChange={(e) => setPreviewRarity(e.target.value)}
              style={{ width: '100%', padding: '10px', background: '#000', color: '#fff', border: '1px solid #444', borderRadius: '6px', marginBottom: '25px' }}
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

function SettingsPage({ stats, setStats, questCapacity, setQuestCapacity }) {
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

  const addNewStat = () => {
    if (!newStatName || stats.find(s => s.subject.toLowerCase() === newStatName.toLowerCase())) return;
    setStats([...stats, { subject: newStatName, A: 10, weight: 1.0 }]);
    setNewStatName('');
  };

  const deleteStat = (index) => {
    if (stats.length <= 3) return alert("Min 3 stats required!");
    setStats(stats.filter((_, i) => i !== index));
    setExpanded(-1);
  };

  return (
    <div>
      <h3>System Tuning</h3>
      <div style={{ background: '#242424', padding: '15px', borderRadius: '12px', marginBottom: '20px', border: '1px solid #444' }}>
        <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: '10px' }}>
          <span>Daily Quest Slots</span>
          <span style={{ color: '#646cff', fontWeight: 'bold' }}>{questCapacity}</span>
        </div>
        <input type="range" min="1" max="10" value={questCapacity} onChange={(e) => setQuestCapacity(Number(e.target.value))} style={{ width: '100%' }} />
      </div>

      <h3>Add New Attribute</h3>
      <div style={{ display: 'flex', gap: '5px', marginBottom: '20px' }}>
        <input placeholder="New Stat..." value={newStatName} onChange={(e) => setNewStatName(e.target.value)} style={{ flex: 1, padding: '10px', background: '#1a1a1a', color: 'white', border: '1px solid #444' }} />
        <button onClick={addNewStat} style={{ backgroundColor: '#646cff', color: 'white', border: 'none', padding: '10px', cursor: 'pointer' }}>CREATE</button>
      </div>

      <h3>Stat Weights & Levels</h3>
      {stats.map((s, i) => (
        <div key={s.subject} style={{ border: '1px solid #333', marginBottom: '8px', borderRadius: '8px', overflow: 'hidden' }}>
          <div onClick={() => setExpanded(expanded === i ? -1 : i)} style={{ padding: '12px', cursor: 'pointer', display: 'flex', justifyContent: 'space-between', background: expanded === i ? '#1a1a1a' : 'transparent' }}>
            <div><span style={{ fontWeight: 'bold' }}>{s.subject}</span><div style={{ fontSize: '0.7rem', color: '#888' }}>Level {s.A}</div></div>
            <div style={{ color: '#646cff', fontSize: '0.8rem' }}>{((s.weight / totalWeight) * 100).toFixed(1)}% Spawn</div>
          </div>
          {expanded === i && (
            <div style={{ padding: '15px', background: '#111', borderTop: '1px solid #333' }}>
              <label style={{ fontSize: '0.7rem', color: '#888' }}>BASE LEVEL ({s.A})</label>
              <input type="range" min="0" max="100" value={s.A} onChange={(e) => updateStat(i, 'A', e.target.value)} style={{ width: '100%', marginBottom: '15px' }} />
              <label style={{ fontSize: '0.7rem', color: '#888' }}>SPAWN WEIGHT</label>
              <input type="range" min="0.1" max="5" step="0.1" value={s.weight} onChange={(e) => updateStat(i, 'weight', e.target.value)} style={{ width: '100%' }} />
              <button onClick={() => deleteStat(i)} style={{ marginTop: '15px', width: '100%', padding: '8px', border: '1px solid #ff3e3e', color: '#ff3e3e', background: 'transparent', cursor: 'pointer' }}>DELETE</button>
            </div>
          )}
        </div>
      ))}
    </div>
  );
}

export default App;