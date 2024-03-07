// MyComponent.tsx
import React, { useEffect, useState } from 'react';
import { fetchData } from '../services/apiService';

interface WeatherData {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

const MyComponent: React.FC = () => {
  const [weatherData, setWeatherData] = useState<WeatherData[]>([]);

  useEffect(() => {
    const fetchDataAsync = async () => {
      try {
        const result = await fetchData('https://localhost:7121/WeatherForecast');
        setWeatherData(result);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchDataAsync();
  }, []);

  return (
    <div>
      {weatherData.length > 0 ? (
        <div>
        <h1>Weather Data</h1>
        <table>
          <thead>
            <tr>
              <th>Date</th>
              <th>Temperature (C)</th>
              <th>Temperature (F)</th>
              <th>Summary</th>
            </tr>
          </thead>
          <tbody>
            {weatherData.map((data, index) => (
              <tr key={index}>
                <td>{data.date}</td>
                <td>{data.temperatureC}</td>
                <td>{data.temperatureF}</td>
                <td>{data.summary}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      ) : (
        <div>Loading...</div>
      )}
    </div>
  );
};

export default MyComponent;