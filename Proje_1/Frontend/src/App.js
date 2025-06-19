import React, { useEffect, useState } from 'react';
import WeatherCard from './components/WeatherCard';

function App() {
  const [citiesData, setCitiesData] = useState([]);

  useEffect(() => {
    const cities = ["istanbul", "ankara", "izmir", "bursa", "antalya"];

    Promise.all(
      cities.map(city =>
        fetch(`${process.env.REACT_APP_API_URL}/api/weather?city=${city}`)
          .then(res => res.json())
      )
    ).then(results => setCitiesData(results))
     .catch(error => console.error("API'den veri alınamadı:", error));
  }, []);

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center p-8">
      <h1
        className="
          text-4xl md:text-5xl lg:text-6xl 
          font-extrabold 
          text-transparent 
          bg-clip-text 
          bg-gradient-to-r from-blue-500 to-teal-400 
          tracking-wide 
          drop-shadow-md 
          mb-8
        "
      >
        Türkiye Hava Durumları
      </h1>

      <div className="flex flex-wrap justify-center items-center gap-6 pt-20">
        {citiesData.map((city, index) => (
          <WeatherCard key={index} data={city} />
        ))}
      </div>
    </div>
  );
}

export default App;

