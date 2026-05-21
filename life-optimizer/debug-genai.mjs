import { GoogleGenAI } from '@google/genai';

const apiKey = 'AIzaSyCazZRdlYVsFWgLj1U4vRLif9JMuzDmfPo';
const ai = new GoogleGenAI({ apiKey });

try {
  const response = await ai.models.generateContent({
    model: 'gemini-2.5-flash',
    contents: 'Generate a short RPG quest description for learning math.',
    config: { responseMimeType: 'application/json' },
  });
  console.log('RESPONSE_OK');
  console.log(response);
} catch (error) {
  console.error('RESPONSE_ERR');
  console.error(error);
  process.exit(1);
}
