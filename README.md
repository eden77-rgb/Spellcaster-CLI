# Spellcaster CLI
Application C# en console, qui propose une correction de texte via intelligence artificielle, une traduction de texte du français vers l'anglais (US) ou l'anglais (UK), et la génération 
d'une page HTML composée de 6 articles avec des thèmes similaires.

---

## Table des matières
1. [Aperçu](#aperçu)
2. [Fonctionnalités](#fonctionnalités)
3. [Installation](#installation)
4. [Utilisation](#utilisation)
5. [Licence](#licence)
6. [Crédits](#crédits)

---

## Aperçu
Spellcaster CLI est un outil en ligne de commande qui utilise des fonctionnalités basées sur des API avec une interface utilisateur simple. Il permet de :
- Corriger les fautes d'orthographe et de grammaire d'un texte.
- Traduire un texte du français vers l'anglais US ou UK.
- Générer une page HTML avec 6 articles d'actualité autour de différents thèmes.

---

## Fonctionnalités
- **Correction des fautes** :
  - Interroge l'API d'OpenAI pour corriger un texte entré par l'utilisateur.
- **Traduction vers l'anglais (US) ou (UK)** :
  - Interroge l'API d'OpenAI pour traduire un texte entré par l'utilisateur en fonction de la variante de langue choisie.
- **Génération d'une page HTML** :
  - Interroge l'API de NewsAPI pour récupérer 6 articles d'actualité en fonction des thèmes suivants : Économie, Divertissement, Général, Santé, Sciences, Sport ou Technologie.

---

## Installation
### Prérequis
- .NET 8.0 ou toute version ultérieure installée sur votre machine.
- Une clé API valide pour [OpenAI](https://platform.openai.com/api-keys) et pour [NewsAPI](https://newsapi.org/).

---

### Étapes
1. Clonez le dépôt :
   ```bash
   git clone https://github.com/eden77-rgb/Spellcaster-CLI.git
   ```
2. Accédez au répertoire du projet :
   ```bash
   cd Spellcaster-CLI/Spellcaster CLI
   ```
3. Configurez vos clés API dans votre environnement :
   - Créez un fichier `.env` au format du fichier `.env.example` à la racine du projet.
   - Ajoutez-y vos clés API sous la forme suivante :
     ```
     OPENAI_API_KEY=VotreCleAPI
     NEWSAPI_API_KEY=VotreCleAPI
     ```
4. Exécutez le projet avec :
   ```bash
   dotnet run
   ```

---

## Utilisation
Lorsque vous exécutez le projet, le programme vous guide via un menu interactif. Voici les principales options disponibles :

1. **Correction de texte** :
   - Entrez un texte pour que le programme le corrige à l'aide de l'API OpenAI.

2. **Traduction en anglais** :
   - Traduisez un texte en anglais en choisissant entre l'anglais britannique et l'anglais américain.

3. **Génération de fichiers HTML** :
   - Choisissez un thème parmi les options disponibles :
     ```
     1. Économie
     2. Divertissement
     3. Général
     4. Santé
     5. Sciences
     6. Sport
     7. Technologie
     ```
   - Un fichier HTML sera généré dans le dossier `output`. Vous pouvez également le lancer directement depuis le programme.

---

## Licence

Ce projet est sous licence MIT. Consultez le fichier `LICENSE` pour plus d'informations.

---

## Crédits

- **Développeur principal** : [eden77-rgb](https://github.com/eden77-rgb)
- **API utilisées** :
  - [OpenAI API](https://openai.com/)
  - [NewsAPI](https://newsapi.org/)
