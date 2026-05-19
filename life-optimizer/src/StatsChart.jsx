import { ResponsiveContainer, RadarChart, Radar, PolarGrid, PolarAngleAxis, PolarRadiusAxis } from 'recharts'; // Make sure PolarRadiusAxis is imported!

// This is "Dummy Data" - eventually this will come from your C# Backend!




// Remove the 'const data = [...]' from this file! 

function StatsChart({ stats }) { 
  return (
    <div style={{ width: '100%', height: 300 }}>
      <ResponsiveContainer width="100%" height="100%">
        <RadarChart cx="50%" cy="50%" outerRadius="80%" data={stats}>
          <PolarGrid stroke="#444" />
          <PolarAngleAxis dataKey="subject" tick={{ fill: '#646cff' }} />
          
          {/* 👇 ADD THIS LINE HERE 👇 */}
          <PolarRadiusAxis domain={[0, 100]} tick={false} axisLine={false} />

          <Radar
            name="Stats"
            dataKey="A" 
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