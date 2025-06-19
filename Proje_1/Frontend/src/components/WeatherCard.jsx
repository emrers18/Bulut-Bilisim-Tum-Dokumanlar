import React from 'react';

export default function WeatherCard({ data }) {
  const {
    name,
    main: { temp, humidity },
    weather: [weatherInfo],
    wind: { speed },
  } = data;

  const emoji = {
    Clear: '☀️',
    Clouds: '☁️',
    Rain: '🌧️',
    Snow: '❄️',
    Drizzle: '🌦️',
    Thunderstorm: '⛈️',
  }[weatherInfo.main] || '🌈';

  return (
    <div className="w-64 bg-gradient-to-br from-blue-400 to-blue-600 text-white rounded-2xl shadow-xl p-6 flex flex-col items-center">
      <h2 className="text-2xl font-semibold mb-2">{name}</h2>
      <div className="text-6xl mb-2">{emoji}</div>
      <div className="text-4xl font-bold mb-1">{Math.round(temp)}°C</div>
      <div className="capitalize mb-4 text-sm">{weatherInfo.description}</div>
      <div className="w-full flex justify-between text-xs">
        <div>
          <p className="font-medium">Nem</p>
          <p>{humidity}%</p>
        </div>
        <div>
          <p className="font-medium">Rüzgâr</p>
          <p>{speed} m/s</p>
        </div>
      </div>
    </div>
  );
}
