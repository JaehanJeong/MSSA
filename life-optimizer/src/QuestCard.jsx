function QuestCard({ title, description, stat, rarity, xp, onComplete, onReroll, onDelete }) {
  // Simple color mapping to give each rarity visual weight
  const rarityColors = {
    Common: '#888888',
    Rare: '#646cff',
    Epic: '#a335ee',
    Legendary: '#ff8000'
  };

  return (
    <div style={{
      border: `2px solid ${rarityColors[rarity] || '#646cff'}`,
      borderRadius: '12px',
      padding: '20px',
      margin: '10px 0',
      backgroundColor: '#1a1a1a',
      color: 'white',
      width: '100%',
      boxSizing: 'border-box',
      position: 'relative'
    }}>
      <div style={{ 
        position: 'absolute', top: '12px', right: '15px', 
        fontSize: '0.65rem', fontWeight: 'bold', letterSpacing: '1px',
        color: rarityColors[rarity] || '#646cff'
      }}>
        {rarity?.toUpperCase()}
      </div>

      <h3 style={{ color: '#646cff', margin: '0 0 10px 0', maxWidth: '80%' }}>{title}</h3>
      {description && <p style={{ margin: '0 0 10px 0', color: '#ccc', fontSize: '0.9rem' }}>{description}</p>}
      
      <div style={{ display: 'flex', justifyContent: 'space-between', fontSize: '0.8rem', color: '#aaa', marginBottom: '15px' }}>
        <div>Boosts: <strong style={{ color: 'white' }}>{stat} (+0.5 Lv)</strong></div>
        <div style={{ color: '#646cff', fontWeight: 'bold' }}>+{xp} Global XP</div>
      </div>

      <div style={{ display: 'flex', gap: '8px' }}>
        <button 
          onClick={onComplete}
          style={{ 
            backgroundColor: rarityColors[rarity] || '#646cff', 
            color: 'white', 
            border: 'none', 
            padding: '10px',
            borderRadius: '8px',
            cursor: 'pointer',
            flex: 1,
            fontWeight: 'bold'
          }}
        >
          Complete Quest
        </button>

        <button
          onClick={onReroll}
          style={{
            background: 'transparent',
            border: '1px solid #444',
            color: '#ffd966',
            padding: '10px',
            borderRadius: '8px',
            cursor: 'pointer',
            fontWeight: 'bold'
          }}
        >
          Reroll
        </button>

        <button
          onClick={onDelete}
          style={{
            background: 'transparent',
            border: '1px solid #ff3e3e',
            color: '#ff3e3e',
            padding: '10px',
            borderRadius: '8px',
            cursor: 'pointer',
            fontWeight: 'bold'
          }}
        >
          Remove
        </button>
      </div>
    </div>
  );
}

export default QuestCard;