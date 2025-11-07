# Progression System (Quêtes)

## Présentation
Ce module permet de créer, configurer et gérer des quêtes complexes dans Unity, avec une structure flexible basée sur des ScriptableObjects et des classes runtime.

---

## Structure principale

- **QuestDataSO** : ScriptableObject décrivant une quête (id, titre, description, étapes).
- **QuestStepDataSO** : ScriptableObject pour une étape de quête, contenant une liste d'objectifs.
- **ObjectiveDataSO** : ScriptableObject abstrait pour chaque objectif (à spécialiser selon vos besoins).
- **QuestManager** : MonoBehaviour qui charge les quêtes depuis Resources, instancie l'UI et gère l'activation.
- **Quest** : Classe runtime représentant une quête, progression, événements.
- **QuestStep** : Classe runtime pour une étape, progression, événements.

---

## Fonctionnement

1. **Créer une quête**
   - Créez un asset `QuestDataSO` dans `Assets/Resources/Quest/QuestSO`.
   - Ajoutez des étapes via des assets `QuestStepDataSO`.
   - Ajoutez des objectifs à chaque étape.
   
   Pour ajouter de nouveaux types d'objectifs, dérivez `ObjectiveDataSO` et implémentez `IQuestObjective`
2. **Ajouter le QuestManager**
   - Placez un `QuestManager` dans votre scène, il charge tous les assets `QuestDataSO` au démarrage..
   - Associez-lui le container UI pour les quêtes.
    Pour chaque quête, il crée une instance runtime (`Quest`) et l'ajoute à son dictionnaire..

3. **Activer une quête**
   - Appelez `QuestManager.ActivateQuest("Quest1")` pour démarrer la quête d'id "Quest1".

4. **Progression**
   - Chaque `Quest` contient une liste de `QuestStep`.
   - Chaque `QuestStep` contient une liste d'objectifs runtime (`IQuestObjective`).
   - Les étapes et objectifs notifient leur progression via des events (`OnProgress`, `OnCompleted`).
   - Quand tous les objectifs d'une étape sont terminés, la quête passe à l'étape suivante.
   - Quand toutes les étapes sont terminées, la quête est complétée.

5. **UI**

   5.1. **Notifieur de quêtes**
   
   Permet qu'a chaque fois qu'une nouvelle quetes est activé de notifié le joueur via l'UI.

   Utilisation:
   - Créer un objet qui contiendra le script `NotifierQuestUI` sur lui.
   - Créer un fils `Content`.
   - Créer deux fils à `Content` qui seront des `Text` qui seront le titre et la description de la quêtes.
   - Glissez dans le script `NotifierQuestUI` les élements correspondant.

   5.2. **Traqueur de quêtes**

   Permet de garder une quêtes affichés in-game afin d'aidés le joueur.

   Utilisation:
   - Créer un objet qui contiendra le script `TrackedQuestUI` sur lui.
   - Créer trois fils de type `Text` qui contiendront le titre, la description et l'étape actuelle.
   - Glissez dans le script `TrackedQuestUI` les élements correspondant.

   5.3. **Etendeurs de quêtes**

   Permet d'afficher plus d'informations au survol d'une quêtes.
   Utilisation:
   - Créer un objet qui contiendra le script `ExtentedQuestUI` sur lui.
   - Créer deux fils, un de type `Text` et un de type `Image`.
   - Créer un autre fils vide qui lui va contenir tout les infos
      - Head : Va contenir les titre, la description, la progression ainsi qu'une image de fond.
      - Objectives : Va contenir un template avec la description, le suivi et la description de l'objectif.
      - Rewards : Va contenir un template avec le logo et le nombre d'élements obtenu par le joueur à la fin de la quêtes. 
   - Glissez dans le script `ExtentedQuestUI` les élements correspondant.
