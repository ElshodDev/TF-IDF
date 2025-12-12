using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] documents = {
            "kompyuter tez ishlaydi",
            "telefon tez va qulay",
            "kompyuter va telefon",
            "internet juda foydali",
            "dasturlash qiziqarli mashg‘ulot"
        };

        var tokenizedDocs = documents
            .Select(doc => doc.Split(' '))
            .ToList();

        var allTerms = tokenizedDocs.SelectMany(d => d).Distinct().ToList();

        int N = tokenizedDocs.Count;

        // IDF hisoblash
        var idf = new Dictionary<string, double>();
        foreach (var term in allTerms)
        {
            int df = tokenizedDocs.Count(doc => doc.Contains(term));
            idf[term] = Math.Log((double)N / df);
        }

        // TF–IDF natijalarini chiqarish
        foreach (var term in allTerms)
        {
            Console.WriteLine($"So‘z: {term}");

            for (int i = 0; i < tokenizedDocs.Count; i++)
            {
                var doc = tokenizedDocs[i];
                double tf = doc.Count(t => t == term) / (double)doc.Length;
                double tfidf = tf * idf[term];

                Console.WriteLine($"  Hujjat {i + 1}: TF={tf:F4}, IDF={idf[term]:F4}, TF-IDF={tfidf:F4}");
            }
            Console.WriteLine();
        }

        // TF–IDF vektorlarini yaratish
        var tfidfVectors = new List<Dictionary<string, double>>();
        foreach (var doc in tokenizedDocs)
        {
            var tfidf = new Dictionary<string, double>();
            foreach (var term in allTerms)
            {
                double tf = doc.Count(t => t == term) / (double)doc.Length;
                tfidf[term] = tf * idf[term];
            }
            tfidfVectors.Add(tfidf);
        }

        // Cosine Similarity juftliklar bo‘yicha
        Console.WriteLine("\n--- Cosine O'xshashlik Natijalari ---\n");

        for (int i = 0; i < tfidfVectors.Count; i++)
        {
            for (int j = i + 1; j < tfidfVectors.Count; j++)
            {
                double similarity = CosineSimilarity(tfidfVectors[i], tfidfVectors[j]);
                Console.WriteLine($"Hujjat {i + 1} ↔ Hujjat {j + 1}  O'xshashlik = {similarity:F4}");
            }
        }
    }

    static double CosineSimilarity(Dictionary<string, double> vec1, Dictionary<string, double> vec2)
    {
        double dot = 0, mag1 = 0, mag2 = 0;

        foreach (var key in vec1.Keys)
        {
            dot += vec1[key] * vec2[key];
            mag1 += vec1[key] * vec1[key];
            mag2 += vec2[key] * vec2[key];
        }

        return dot / (Math.Sqrt(mag1) * Math.Sqrt(mag2) + 1e-10);
    }
}
