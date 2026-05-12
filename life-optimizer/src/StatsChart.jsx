import { Radar, RadarChart, PolarGrid, PolarAngleAxis, ResponsiveContainer } from 'recharts';

// This is "Dummy Data" - eventually this will come from your C# Backend!




// Remove the 'const data = [...]' from this file! 

function StatsChart({ stats }) { // Accept stats as a prop
  return (
    <div style={{ width: '100%', height: 300 }}>
      <ResponsiveContainer width="100%" height="100%">
        <RadarChart cx="50%" cy="50%" outerRadius="80%" data={stats}> {/* Use stats here */}
          <PolarGrid stroke="#444" />
          <PolarAngleAxis dataKey="subject" tick={{ fill: '#646cff' }} />
          <Radar
            name="Stats"
            dataKey="A" // This stays the same as it maps to the 'A' value in our objects
            stroke="#646cff"
            fill="#646cff"
            fillOpacity={0.6}
          />
        </RadarChart>
      </ResponsiveContainer>
    </div>
  );
}

export default StatsChart;