function QuestCard({ title, description, stat }) {
  return (
    <div style={{
      border: '2px solid #646cff',
      borderRadius: '12px',
      padding: '20px',
      margin: '10px',
      backgroundColor: '#1a1a1a',
      color: 'white',
      maxWidth: '300px'
    }}>
      <h3 style={{ color: '#646cff' }}>{title}</h3>
      <p>{description}</p>
      <div style={{ fontSize: '0.8rem', color: '#aaa', marginBottom: '10px' }}>
         Boosts: <strong>{stat}</strong>
      </div>
      <button style={{ 
        backgroundColor: '#646cff', 
        color: 'white', 
        border: 'none', 
        padding: '10px',
        borderRadius: '8px',
        cursor: 'pointer' 
      }}>
        Complete Quest
      </button>
    </div>
  );
}

export default QuestCard;