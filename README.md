# TF — Term Frequency (So‘z chastotasi)

# IDF — Inverse Document Frequency (Aks hujjat chastotasi)

# TF–IDF va Cosine Similarity C# Dasturi

Ushbu dastur **C#** tilida yozilgan bo‘lib, matnli hujjatlar ustida **TF (Term Frequency)**, **IDF (Inverse Document Frequency)** va **TF–IDF** vektorlarini hisoblaydi hamda hujjatlar orasidagi **Cosine Similarity** ni aniqlaydi.

---

## Xususiyatlar

- Hujjatlar matnini so‘zlarga ajratish (tokenization).
- Hujjatlar korpusidagi noyob so‘zlarni aniqlash.
- Har bir so‘z uchun **TF, IDF, TF–IDF** qiymatlarini hisoblash.
- Hujjatlar orasidagi **Cosine Similarity** ni juftliklar bo‘yicha chiqarish.
- Natijalar **konsolga chiroyli ko‘rinishda** chiqariladi.

---

## Ishlatish

1. Kodni **C# Console Application** loyihasiga joylashtiring.
2. `documents` massivini o‘zingizning matnli hujjatlaringiz bilan yangilang:

```csharp
string[] documents = {
    "kompyuter tez ishlaydi",
    "telefon tez va qulay",
    "kompyuter va telefon",
    "internet juda foydali",
    "dasturlash qiziqarli mashg‘ulot"
};
```
