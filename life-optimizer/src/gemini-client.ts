import { GoogleGenAI } from '@google/genai';

// Initialize the client
const ai = new GoogleGenAI({
  apiKey: process.env.GEMINI_API_KEY || 'YOUR_API_KEY'
});

/**
 * Generates a "quest" based on a specific life goal or topic.
 */
export async function generateQuest(topic: string) {
  try {
    const result = await ai.models.generateContent({
      model: 'gemini-1.5-flash',
      contents: `Generate a creative life-optimization quest for: ${topic}. 
      Include a catchy title, a brief description, and 3 actionable milestones.`
    });

    return result.text;
  } catch (error) {
    console.error('Gemini Error:', error);
    throw error;
  }
}

/**
 * Quick test execution
 */
async function testQuest() {
  console.log('🚀 Testing Quest Generation...');
  const quest = await generateQuest('Waking up earlier');
  console.log('\n--- Generated Quest ---\n');
  console.log(quest);
}

// Run test if this file is executed directly
if (require.main === module) {
  testQuest();
}