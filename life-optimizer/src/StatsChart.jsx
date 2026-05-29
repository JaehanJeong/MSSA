import { ResponsiveContainer, RadarChart, Radar, PolarGrid, PolarAngleAxis, PolarRadiusAxis } from 'recharts';

const CustomTick = ({ x, y, payload, textAnchor }) => (
  <text
    x={x}
    y={y}
    textAnchor={textAnchor}
    dominantBaseline="middle"
    fill="#f59e0b"
    fontSize={12}
    fontFamily="'Rajdhani', system-ui, sans-serif"
    fontWeight={600}
    letterSpacing="1.5px"
    style={{ textTransform: 'uppercase' }}
  >
    {payload.value.toUpperCase()}
  </text>
);

function StatsChart({ stats }) {
  return (
    <div style={{ width: '100%', height: 300 }}>
      <ResponsiveContainer width="100%" height="100%">
        <RadarChart cx="50%" cy="50%" outerRadius="75%" data={stats}>
          <PolarGrid stroke="#2a2000" />
          <PolarAngleAxis dataKey="subject" tick={<CustomTick />} />
          <PolarRadiusAxis domain={[0, 100]} tick={false} axisLine={false} />
          <Radar
            name="Stats"
            dataKey="A"
            stroke="#f59e0b"
            fill="#f59e0b"
            fillOpacity={0.25}
          />
        </RadarChart>
      </ResponsiveContainer>
    </div>
  );
}

export default StatsChart;
