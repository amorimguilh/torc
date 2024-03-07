// apiService.ts
import axios from 'axios';

export async function fetchData(url: string): Promise<any> {
  try {
    const response = await axios.get(url);
    return response.data;
  } catch (error) {
    throw new Error('Error fetching data');
  }
}