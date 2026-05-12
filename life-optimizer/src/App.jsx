import { useState } from 'react';
import { Routes, Route, Link, useLocation } from 'react-router-dom';
import StatsChart from './StatsChart';

// --- GAMIFICATION CONSTANTS ---
const RARITY_SETTINGS = {
  Common: { color: '#888', xp: 5 },
  Rare: { color: '#646cff', xp: 15 },
  Epic: { color: '#a335ee', xp: 50 },
  Legendary: { color: '#ff8000', xp: 150 },
  Mythic: { color: '#ff3e3e', xp: 1000 }, // For massive feats like Marathons
};

function App() {
  const location = useLocation();

  const [stats, setStats] = useState([
    { subject: 'Focus', A: 120, weight: 1.0 },
    { subject: 'Stamina', A: 98, weight: 0.1 },
    { subject: 'Intelligence', A: 86, weight: 2.0 },
    { subject: 'Social', A: 99, weight: 1.0 },
    { subject: 'Health', A: 85, weight: 1.0 },
    { subject: 'Violin', A: 70, weight: 1.5 },
  ]);

  const [questCapacity, setQuestCapacity] = useState(3);

  const [masterQuestPool, setMasterQuestPool] = useState([
    { id: 1, title: "C# Dictionary Practice", stat: "Intelligence", rarity: "Rare" },
    { id: 2, title: "15 Min Vibrato Exercise", stat: "Violin", rarity: "Common" },
    { id: 3, title: "Finish Army ETS Paperwork", stat: "Focus", rarity: "Epic" },
  ]);

  return (
    <div style={{ padding: '20px', maxWidth: '500px', margin: '0 auto', paddingBottom: '80px', color: 'white', minHeight: '100vh', backgroundColor: '#0f0f0f' }}>
      <header><h1 style={{ color: '#646cff', textAlign: 'center', letterSpacing: '2px' }}>LIFE OPTIMIZER</h1></header>

      <main>
        <Routes>
          <Route path="/" element={
            <div>
              <h2 style={{ borderBottom: '1px solid #444', paddingBottom: '10px' }}>Current Build</h2>
              <StatsChart key={JSON.stringify(stats)} stats={stats} /> 
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

// --- QUEST LIBRARY PAGE ---
function QuestPage({ stats, masterQuestPool, setMasterQuestPool }) {
  const [title, setTitle] = useState('');
  const [selectedStat, setSelectedStat] = useState(stats[0]?.subject || '');
  const [rarity, setRarity] = useState('Common');

  const addQuest = () => {
    if (!title) return;
    setMasterQuestPool([...masterQuestPool, { id: Date.now(), title, stat: selectedStat, rarity }]);
    setTitle('');
  };

  const grouped = stats.reduce((acc, s) => {
    acc[s.subject] = masterQuestPool.filter(q => q.stat === s.subject);
    return acc;
  }, {});

  return (
    <div>
      <h3>Master Library</h3>
      <details style={{ background: '#242424', padding: '15px', borderRadius: '12px', marginBottom: '20px', border: '1px solid #333' }}>
        <summary style={{ cursor: 'pointer', color: '#646cff', fontWeight: 'bold' }}>+ Create New Quest Template</summary>
        <input 
          placeholder="Quest Title..." value={title} onChange={(e) => setTitle(e.target.value)}
          style={{ width: '95%', padding: '10px', margin: '15px 0 10px 0', background: '#000', color: 'white', border: '1px solid #444', borderRadius: '4px' }}
        />
        <div style={{ display: 'flex', gap: '5px' }}>
          <select value={selectedStat} onChange={(e) => setSelectedStat(e.target.value)} style={{ flex: 1, padding: '5px' }}>
            {stats.map(s => <option key={s.subject}>{s.subject}</option>)}
          </select>
          <select value={rarity} onChange={(e) => setRarity(e.target.value)} style={{ flex: 1, padding: '5px' }}>
            {Object.keys(RARITY_SETTINGS).map(r => <option key={r}>{r}</option>)}
          </select>
          <button onClick={addQuest} style={{ backgroundColor: '#646cff', color: 'white', border: 'none', padding: '10px 15px', borderRadius: '4px', cursor: 'pointer' }}>ADD</button>
        </div>
      </details>

      {stats.map(s => (
        <div key={s.subject} style={{ marginBottom: '20px' }}>
          <div style={{ borderBottom: '1px solid #333', color: '#888', fontSize: '0.7rem', paddingBottom: '5px', letterSpacing: '1px' }}>{s.subject.toUpperCase()}</div>
          {grouped[s.subject]?.length === 0 && <div style={{ fontSize: '0.8rem', color: '#444', padding: '10px' }}>No templates yet...</div>}
          {grouped[s.subject]?.map(q => (
            <div key={q.id} style={{ 
              background: '#1a1a1a', padding: '12px', margin: '8px 0', borderRadius: '8px', 
              display: 'flex', justifyContent: 'space-between', alignItems: 'center',
              borderLeft: `4px solid ${RARITY_SETTINGS[q.rarity]?.color}`,
              boxShadow: q.rarity === 'Mythic' ? '0 0 15px rgba(255, 62, 62, 0.2)' : 'none'
            }}>
              <div>
                <div style={{ fontWeight: '500' }}>{q.title}</div>
                <div style={{ fontSize: '0.6rem', color: RARITY_SETTINGS[q.rarity]?.color, fontWeight: 'bold', marginTop: '2px' }}>{q.rarity.toUpperCase()}</div>
              </div>
              <div style={{ fontSize: '0.7rem', color: '#646cff', fontWeight: 'bold' }}>+{RARITY_SETTINGS[q.rarity]?.xp} XP</div>
            </div>
          ))}
        </div>
      ))}
    </div>
  );
}

// --- SETTINGS PAGE (TUNING) ---
function SettingsPage({ stats, setStats, questCapacity, setQuestCapacity }) {
  const [expanded, setExpanded] = useState(-1);
  const totalWeight = stats.reduce((acc, s) => acc + s.weight, 0);

  const updateStat = (index, field, value) => {
    const copy = [...stats];
    copy[index][field] = value;
    setStats(copy);
  };

  return (
    <div>
      <h3>System Tuning</h3>
      
      <div style={{ background: '#242424', padding: '15px', borderRadius: '12px', marginBottom: '20px', border: '1px solid #444' }}>
        <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: '10px' }}>
          <span>Daily Quest Slots</span>
          <span style={{ color: '#646cff', fontWeight: 'bold' }}>{questCapacity}</span>
        </div>
        <input 
          type="range" min="1" max="10" value={questCapacity} 
          onChange={(e) => setQuestCapacity(Number(e.target.value))} 
          style={{ width: '100%', accentColor: '#646cff' }}
        />
      </div>

      <h3>Stat Weights & Levels</h3>
      {stats.map((s, i) => {
        const prob = ((s.weight / totalWeight) * 100).toFixed(1);
        return (
          <div key={s.subject} style={{ border: '1px solid #333', marginBottom: '8px', borderRadius: '8px', overflow: 'hidden' }}>
            <div onClick={() => setExpanded(expanded === i ? -1 : i)} 
                 style={{ padding: '12px', cursor: 'pointer', display: 'flex', justifyContent: 'space-between', background: expanded === i ? '#1a1a1a' : 'transparent' }}>
              <div>
                <span style={{ fontWeight: 'bold' }}>{s.subject}</span>
                <div style={{ fontSize: '0.7rem', color: '#888' }}>Level {s.A}</div>
              </div>
              <div style={{ textAlign: 'right' }}>
                <div style={{ color: '#646cff', fontSize: '0.8rem' }}>{prob}% Spawn Rate</div>
              </div>
            </div>
            
            {expanded === i && (
              <div style={{ padding: '15px', background: '#111', borderTop: '1px solid #333' }}>
                <div style={{ marginBottom: '15px' }}>
                  <label style={{ fontSize: '0.7rem', color: '#888', display: 'block', marginBottom: '5px' }}>BASE LEVEL</label>
                  <input type="range" min="0" max="200" value={s.A} onChange={(e) => updateStat(i, 'A', Number(e.target.value))} style={{ width: '100%' }} />
                </div>
                <div>
                  <label style={{ fontSize: '0.7rem', color: '#888', display: 'block', marginBottom: '5px' }}>SPAWN WEIGHT (FREQUENCY)</label>
                  <input type="range" min="0.1" max="5" step="0.1" value={s.weight} onChange={(e) => updateStat(i, 'weight', Number(e.target.value))} style={{ width: '100%' }} />
                </div>
              </div>
            )}
          </div>
        );
      })}
    </div>
  );
}

export default App;