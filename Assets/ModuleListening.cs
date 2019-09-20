using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;
using rnd = UnityEngine.Random;

public class ModuleListening : MonoBehaviour 
{
	public KMBombInfo bomb;
	public KMAudio Audio;

	readonly char[] symbols = { '!', '@', '%', '^', '(', '_', '|', '\\', '\'', '<' };

	public AudioClip[] AMistake;
	public AudioClip[] Bartending;
	public AudioClip[] Battleship;
	public AudioClip[] BenedictCumberbatch;
	public AudioClip[] BlackHole;
	public AudioClip[] Blockbusters;
	public AudioClip[] BobBarks;
	public AudioClip[] BootTooBig;
	public AudioClip[] BritishSlang;
	public AudioClip[] BrokenButtons;
	public AudioClip[] BurglarAlarm;
	public AudioClip[] CheapCheckout;
	public AudioClip[] ChordQualities;
	public AudioClip[] ChristmasPresents;
	public AudioClip[] ColoredKeys;
	public AudioClip[] ColoredSquares;
	public AudioClip[] CookieJars;
	public AudioClip[] Creation;
	public AudioClip[] CrystalMaze;
	public AudioClip[] Cube;
	public AudioClip[] DoubleExpert;
	public AudioClip[] DoubleOh;
	public AudioClip[] EncryptedEquations;
	public AudioClip[] EuropeanTravel;
	public AudioClip[] FastMath;
	public AudioClip[] ForgetEnigma;
	public AudioClip[] ForgetMeNow;
	public AudioClip[] FreeParking;
	public AudioClip[] Friendship;
	public AudioClip[] GadgetronVendor;
	public AudioClip[] GraffitiNumbers;
	public AudioClip[] Gridlock;
	public AudioClip[] GuitarChords;
	public AudioClip[] Hexamaze;
	public AudioClip[] HiddenColors;
	public AudioClip[] Hieroglyphics;
	public AudioClip[] Hogwarts;
	public AudioClip[] Hypercube;
	public AudioClip[] Instructions;
	public AudioClip[] JackOLantern;
	public AudioClip[] JewelVault;
	public AudioClip[] Kudosudoku;
	public AudioClip[] Labyrinth;
	public AudioClip[] Laundry;
	public AudioClip[] LEDMath;
	public AudioClip[] Lightspeed;
	public AudioClip[] LondonUnderground;
	public AudioClip[] LuckyDice;
	public AudioClip[] Maintenance;
	public AudioClip[] Mazematics;
	public AudioClip[] MegaMan2;
	public AudioClip[] Minesweeper;
	public AudioClip[] Moon;
	public AudioClip[] MortalKombat;
	public AudioClip[] Necronomicon;
	public AudioClip[] Neutralization;
	public AudioClip[] Nonograms;
	public AudioClip[] NumberCipher;
	public AudioClip[] NumberNimbleness;
	public AudioClip[] OnlyConnect;
	public AudioClip[] Painting;
	public AudioClip[] PartialDerivatives;
	public AudioClip[] PerspectivePegs;
	public AudioClip[] QuizzBuzz;
	public AudioClip[] Qwirkle;
	public AudioClip[] Rhythms;
	public AudioClip[] RPSLS;
	public AudioClip[] SchlagDenBomb;
	public AudioClip[] SevenDeadlySins;
	public AudioClip[] ShapesAndBombs;
	public AudioClip[] SillySlots;
	public AudioClip[] SimonSamples;
	public AudioClip[] SimonSelects;
	public AudioClip[] SimonSends;
	public AudioClip[] SimonSimons;
	public AudioClip[] SimonSings;
	public AudioClip[] SimonStores;
	public AudioClip[] SimonsStages;
	public AudioClip[] Sink;
	public AudioClip[] SonicTheHedgehog;
	public AudioClip[] Souvenir;
	public AudioClip[] Sphere;
	public AudioClip[] StreetFighter;
	public AudioClip[] Swan;
	public AudioClip[] Synchronization;
	public AudioClip[] Tangrams;
	public AudioClip[] TashaSqueals;
	public AudioClip[] Tennis;
	public AudioClip[] TreasureHunt;
	public AudioClip[] TurtleRobot;
	public AudioClip[] UnphairCipher;
	public AudioClip[] Valves;
	public AudioClip[] VisualImpairment;
	public AudioClip[] WasteManagement;
	public AudioClip[] Wavetapping;
	public AudioClip[] Wire;
	public AudioClip[] WordSearch;
	public AudioClip[] XRay;
	public AudioClip[] X01;
	public AudioClip[] Yahtzee;
	public AudioClip[] Zoni;

	public AudioSource sound;
	AudioClip[][] audioLibrary;
	String[] moduleNames = {
		"A Mistake",
		"Bartending",
		"Battleship",
		"Benedict Cumberbatch",
		"Black Hole",
		"Blockbusters",
		"Bob Barks",
		"Boot Too Big",
		"British Slang",
		"Broken Buttons",
		"Burglar Alarm",
		"Cheap Checkout",
		"Chord Qualities",
		"Christmas Presents",
		"Colored Keys",
		"Colored Squares",
		"Cookie Jars",
		"Creation",
		"The Crystal Maze",
		"The Cube",
		"Double Expert",
		"Double-Oh",
		"Encrypted Equations",
		"European Travel",
		"Fast Math",
		"Forget Enigma",
		"Forget Me Now",
		"Free Parking",
		"Friendship",
		"Gadgetron Vendor",
		"Graffiti Numbers",
		"Gridlock",
		"Guitar Chords",
		"Hexamaze",
		"Hidden Colors",
		"Hieroglyphics",
		"Hogwarts",
		"The Hypercube",
		"Instructions",
		"The Jack-O’-Lantern",
		"The Jewel Vault",
		"Kudosudoku",
		"The Labyrinth",
		"Laundry",
		"LED Math",
		"Lightspeed",
		"The London Underground",
		"Lucky Dice",
		"Maintenance",
		"Mazematics",
		"Mega Man 2",
		"Minesweeper",
		"The Moon",
		"Mortal Kombat",
		"The Necronomicon",
		"Neutralization",
		"The Number Cipher",
		"Number Nimbleness",
		"Only Connect",
		"Painting",
		"Partial Derivatives",
		"Perspective Pegs",
		"Quiz Buzz",
		"Qwirkle",
		"Rhythms",
		"Rock-Paper-Scissors-L.-Sp.",
		"Schlag den Bomb",
		"Seven Deadly Sins",
		"Shapes and Bombs",
		"Silly Slots",
		"Simon Samples",
		"Simon Selects",
		"Simon Sends",
		"Simon Simons",
		"Simon Sings",
		"Simon Stores",
		"Simon's Stages",
		"Sink",
		"Sonic The Hedgehog",
		"Souvenir",
		"The Sphere",
		"Street Fighter",
		"The Swan",
		"Synchronization",
		"Tangrams",
		"Tasha Squeals",
		"Tennis",
		"Treasure Hunt",
		"Turtle Robot",
		"Unphair Cipher",
		"Valves",
		"Visual Impairment",
		"Waste Management",
		"Wavetapping",
		"The Wire",
		"Word Search",
		"X-Ray",
		"X01",
		"Yahtzee",
		"Zoni",
	};
	int[][] moduleCodes = {
		new int[] { 5, 6, 7, 0, 4, },
		new int[] { 3, 7, 3, 6, 9, },
		new int[] { 4, 0, 4, 2, 4, },
		new int[] { 6, 4, 1, 3, 2, },
		new int[] { 8, 2, 9, 6, 3, },
		new int[] { 1, 4, 0, 4, 5, },
		new int[] { 2, 1, 6, 8, 3, },
		new int[] { 9, 6, 0, 3, 7, },
		new int[] { 6, 3, 1, 5, 4, },
		new int[] { 0, 6, 4, 6, 5, },
		new int[] { 5, 1, 9, 4, 9, },
		new int[] { 7, 4, 0, 9, 2, },
		new int[] { 4, 7, 3, 2, 3, },
		new int[] { 5, 4, 1, 9, 3, },
		new int[] { 0, 1, 3, 4, 0, },
		new int[] { 2, 9, 6, 4, 4, },
		new int[] { 4, 7, 0, 5, 2, },
		new int[] { 9, 9, 2, 2, 4, },
		new int[] { 8, 8, 6, 4, 3, },
		new int[] { 6, 1, 6, 8, 3, },
		new int[] { 0, 1, 5, 3, 0, },
		new int[] { 5, 9, 8, 7, 8, },
		new int[] { 6, 0, 4, 6, 7, },
		new int[] { 2, 0, 3, 6, 4, },
		new int[] { 5, 9, 5, 0, 2, },
		new int[] { 0, 1, 0, 3, 5, },
		new int[] { 2, 3, 0, 3, 3, },
		new int[] { 3, 0, 9, 7, 7, },
		new int[] { 9, 8, 8, 7, 4, },
		new int[] { 4, 5, 2, 0, 6, },
		new int[] { 7, 5, 1, 9, 2, },
		new int[] { 2, 7, 8, 4, 7, },
		new int[] { 9, 0, 8, 6, 0, },
		new int[] { 8, 4, 3, 9, 0, },
		new int[] { 5, 8, 2, 7, 0, },
		new int[] { 0, 8, 2, 0, 4, },
		new int[] { 3, 4, 2, 6, 7, },
		new int[] { 3, 0, 0, 4, 7, },
		new int[] { 0, 3, 9, 2, 4, },
		new int[] { 8, 1, 7, 7, 6, },
		new int[] { 6, 4, 1, 8, 3, },
		new int[] { 5, 6, 2, 9, 6, },
		new int[] { 5, 9, 5, 6, 5, },
		new int[] { 1, 4, 8, 4, 8, },
		new int[] { 1, 7, 0, 3, 5, },
		new int[] { 8, 5, 0, 3, 8, },
		new int[] { 1, 2, 9, 8, 5, },
		new int[] { 6, 9, 4, 7, 1, },
		new int[] { 6, 8, 6, 6, 9, },
		new int[] { 8, 4, 0, 2, 8, },
		new int[] { 0, 4, 7, 4, 5, },
		new int[] { 8, 4, 2, 1, 5, },
		new int[] { 3, 9, 0, 6, 2, },
		new int[] { 6, 8, 8, 7, 6, },
		new int[] { 2, 7, 7, 9, 0, },
		new int[] { 4, 3, 5, 9, 0, },
		new int[] { 4, 0, 3, 8, 7, },
		new int[] { 1, 8, 0, 3, 3, },
		new int[] { 6, 4, 9, 1, 5, },
		new int[] { 3, 0, 4, 0, 8, },
		new int[] { 8, 8, 0, 2, 3, },
		new int[] { 1, 3, 1, 6, 5, },
		new int[] { 8, 5, 0, 2, 3, },
		new int[] { 3, 3, 3, 1, 4, },
		new int[] { 9, 6, 0, 2, 2, },
		new int[] { 0, 7, 4, 4, 9, },
		new int[] { 6, 8, 8, 2, 7, },
		new int[] { 4, 8, 7, 0, 8, },
		new int[] { 3, 1, 1, 4, 3, },
		new int[] { 3, 5, 5, 4, 5, },
		new int[] { 4, 5, 2, 1, 0, },
		new int[] { 3, 2, 1, 0, 9, },
		new int[] { 1, 9, 5, 5, 5, },
		new int[] { 6, 4, 1, 1, 0, },
		new int[] { 5, 6, 3, 6, 6, },
		new int[] { 0, 3, 1, 8, 5, },
		new int[] { 8, 0, 5, 4, 2, },
		new int[] { 0, 9, 6, 1, 0, },
		new int[] { 3, 6, 9, 0, 3, },
		new int[] { 3, 9, 9, 0, 2, },
		new int[] { 1, 4, 7, 7, 7, },
		new int[] { 3, 7, 6, 3, 3, },
		new int[] { 8, 0, 1, 1, 6, },
		new int[] { 2, 1, 5, 4, 1, },
		new int[] { 0, 9, 0, 5, 9, },
		new int[] { 9, 6, 1, 4, 9, },
		new int[] { 7, 4, 0, 0, 4, },
		new int[] { 0, 1, 6, 0, 0, },
		new int[] { 6, 3, 9, 9, 5, },
		new int[] { 5, 1, 8, 8, 5, },
		new int[] { 5, 6, 5, 0, 0, },
		new int[] { 0, 5, 7, 0, 6, },
		new int[] { 9, 5, 9, 3, 0, },
		new int[] { 5, 0, 9, 3, 4, },
		new int[] { 2, 3, 6, 5, 0, },
		new int[] { 8, 8, 0, 8, 0, },
		new int[] { 8, 3, 5, 8, 7, },
		new int[] { 0, 8, 9, 7, 6, },
		new int[] { 0, 4, 2, 6, 4, },
		new int[] { 2, 4, 2, 4, 5, },
	};
	String[] royalFlush = { "Benedict Cumberbatch", "Blockbusters", "British Slang", "Christmas Presents", "The Crystal Maze", "The Cube", "European Travel", "Free Parking", "Graffiti Numbers", "Guitar Chords", "Hieroglyphics", "The Jack-O'-Lantern", "The Jewel Vault", "The Labyrinth", "Lightspeed", "The London Underground", "Maintenance", "The Moon", "Mortal Kombat", "The Number Cipher", "Simon's Stages", "Sonic the Hedgehog", "The Sphere", "Street Fighter", "The Swan", "The Wire" };
	String[] timwi = { "Battleship"," Black Hole", "Colored Squares", "Double-Oh", "Friendship", "Gridlock", "Hexamaze", "Hogwarts"," The Hypercube", "Kudosudoku", "Only Connect", "Rock-Paper-Scissors-L.-Sp.", "Simon Sends", "Simon Sings", "Souvenir", "Tennis", "Word Search", "X-Ray", "Yahtzee" };
	String[] LeGeND = { "Colored Keys", "Gadgetron Vendor", "Hidden Colors", "The Jack-O'-Lantern", "LED Math", "Zoni" };
	String[] theThirdMan = { "Boot Too Big", "Double Expert", "Lucky Dice", "The Necronomicon", "Qwirkle", "Seven Deadly Sins", "Treasure Hunt" };

	//Logging
	static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

	public KMSelectable[] playBtns;
	public KMSelectable[] symbolBtns;

	public Material[] buttonMats;

	public GameObject cassette;
	public Material[] cassetteMats;

	int[] btnColors;
	int[] moduleIndex = new int[4];
	int[] soundIndex = new int[4];
	int[][] codes = new int[4][];
	int[] answer;

	List<int> input = new List<int>();

	void Awake()
	{
		moduleId = moduleIdCounter++;

		playBtns[0].OnInteract += delegate () { PressPlay(0); return false; };
		playBtns[1].OnInteract += delegate () { PressPlay(1); return false; };
		playBtns[2].OnInteract += delegate () { PressPlay(2); return false; };
		playBtns[3].OnInteract += delegate () { PressPlay(3); return false; };

		symbolBtns[0].OnInteract += delegate () { PressSymbol(0); return false; };
		symbolBtns[1].OnInteract += delegate () { PressSymbol(1); return false; };
		symbolBtns[2].OnInteract += delegate () { PressSymbol(2); return false; };
		symbolBtns[3].OnInteract += delegate () { PressSymbol(3); return false; };
		symbolBtns[4].OnInteract += delegate () { PressSymbol(4); return false; };
		symbolBtns[5].OnInteract += delegate () { PressSymbol(5); return false; };
		symbolBtns[6].OnInteract += delegate () { PressSymbol(6); return false; };
		symbolBtns[7].OnInteract += delegate () { PressSymbol(7); return false; };
		symbolBtns[8].OnInteract += delegate () { PressSymbol(8); return false; };
		symbolBtns[9].OnInteract += delegate () { PressSymbol(9); return false; };

	}

	void PressPlay(int btn)
	{
		playBtns[btn].AddInteractionPunch(.5f);

		cassette.GetComponentInChildren<Renderer>().material = cassetteMats[btnColors[btn]];

		sound.clip = audioLibrary[moduleIndex[btn]][soundIndex[btn]];
		sound.Play();
		input.Clear();
	}

	void PressSymbol(int btn)
	{
		GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
		symbolBtns[btn].AddInteractionPunch(.5f);

		if(moduleSolved)
			return;

		input.Add(btn);

		if(input.Count() == 20)
		{
			if(input.SequenceEqual(answer))
			{
				GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.CorrectChime, transform);
        		Debug.LogFormat("[Module Listening #{0}] Input is correct. Module solved.", moduleId);
				GetComponent<KMBombModule>().HandlePass();
				moduleSolved = true;
			}
			else
			{
        		Debug.LogFormat("[Module Listening #{0}] Strike! Received input: [ {1} ].", moduleId, input.Select(x => symbols[x]).Join(""));
				GetComponent<KMBombModule>().HandleStrike();
				input.Clear();
			}
		}
		else if(input.Count() % 5 == 0)
		{
			Audio.PlaySoundAtTransform("ding", transform);
		}
	}

	void Start () 
	{
		LoadAudioLibrary();
		SetUpButtons();
		CalcModifications();
		CalcSubmission();
	}

	void LoadAudioLibrary()
	{
		audioLibrary = new AudioClip[][] {
			AMistake,
			Bartending,
			Battleship,
			BenedictCumberbatch,
			BlackHole,
			Blockbusters,
			BobBarks,
			BootTooBig,
			BritishSlang,
			BrokenButtons,
			BurglarAlarm,
			CheapCheckout,
			ChordQualities,
			ChristmasPresents,
			ColoredKeys,
			ColoredSquares,
			CookieJars,
			Creation,
			CrystalMaze,
			Cube,
			DoubleExpert,
			DoubleOh,
			EncryptedEquations,
			EuropeanTravel,
			FastMath,
			ForgetEnigma,
			ForgetMeNow,
			FreeParking,
			Friendship,
			GadgetronVendor,
			GraffitiNumbers,
			Gridlock,
			GuitarChords,
			Hexamaze,
			HiddenColors,
			Hieroglyphics,
			Hogwarts,
			Hypercube,
			Instructions,
			JackOLantern,
			JewelVault,
			Kudosudoku,
			Labyrinth,
			Laundry,
			LEDMath,
			Lightspeed,
			LondonUnderground,
			LuckyDice,
			Maintenance,
			Mazematics,
			MegaMan2,
			Minesweeper,
			Moon,
			MortalKombat,
			Necronomicon,
			Neutralization,
			NumberCipher,
			NumberNimbleness,
			OnlyConnect,
			Painting,
			PartialDerivatives,
			PerspectivePegs,
			QuizzBuzz,
			Qwirkle,
			Rhythms,
			RPSLS,
			SchlagDenBomb,
			SevenDeadlySins,
			ShapesAndBombs,
			SillySlots,
			SimonSamples,
			SimonSelects,
			SimonSends,
			SimonSimons,
			SimonSings,
			SimonStores,
			SimonsStages,
			Sink,
			SonicTheHedgehog,
			Souvenir,
			Sphere,
			StreetFighter,
			Swan,
			Synchronization,
			Tangrams,
			TashaSqueals,
			Tennis,
			TreasureHunt,
			TurtleRobot,
			UnphairCipher,
			Valves,
			VisualImpairment,
			WasteManagement,
			Wavetapping,
			Wire,
			WordSearch,
			XRay,
			X01,
			Yahtzee,
			Zoni,
		};
	}
	
	void SetUpButtons()
	{
		btnColors = Enumerable.Range(0, 4).OrderBy(x => x = rnd.Range(0, 10000)).ToArray();

		for(int i = 0; i < btnColors.Length; i++)
			playBtns[i].gameObject.transform.GetComponentInChildren<Renderer>().material = buttonMats[btnColors[i]];

		cassette.GetComponentInChildren<Renderer>().material = cassetteMats[btnColors[0]];

        Debug.LogFormat("[Module Listening #{0}] Play button colors are [ {1} ].", moduleId, btnColors.Select(x => buttonMats[x].name).Join(", "));
	
		List<int> used = new List<int>();

		for(int i = 0; i < moduleIndex.Length; i++)
		{
			int r;
			do {
				r = rnd.Range(0, audioLibrary.Length);
			} while(used.Contains(r));

			moduleIndex[i] = r;
			used.Add(r);
			soundIndex[i] = rnd.Range(0, audioLibrary[moduleIndex[i]].Length);

			char[] colorArray = buttonMats[btnColors[i]].name.ToArray();
			colorArray[0] = char.ToUpperInvariant(colorArray[0]);

        	Debug.LogFormat("[Module Listening #{0}] {1} play button module is {2}.", moduleId, new String(colorArray), moduleNames[moduleIndex[i]]);
		
			codes[i] = moduleCodes[moduleIndex[i]];

			Debug.LogFormat("[Module Listening #{0}] {1} play button code (before modifications) is {2}.", moduleId, new String(colorArray), codes[i].Select(x => symbols[x]).Join(""));
		}
	}

	void CalcModifications()
	{
		for(int i = 0; i < codes.Length; i++)
		{
			switch(btnColors[i])
			{
				case 0:
				{
					bool modified = false;

					if(bomb.GetPortCount() >= 4)
					{
						modified = true;
						for(int j = 0; j < codes[i].Length; j++)
							codes[i][j] = (codes[i][j] + 4) % 10;
					}
						
					if(bomb.GetBatteryCount(Battery.AA) == bomb.GetBatteryCount())
					{
						modified = true;
						for(int j = 0; j < codes[i].Length; j++)
							if(codes[i][j] == 0)
								codes[i][j] = 7;
							else if(codes[i][j] == 7)
								codes[i][j] = 0;
							else if(codes[i][j] == 2)
								codes[i][j] = 9;
							else if(codes[i][j] == 9)
								codes[i][j] = 2;
							else if(codes[i][j] == 3)
								codes[i][j] = 8;
							else if(codes[i][j] == 8)
								codes[i][j] = 3;
					}
						
					if("AEIOU".Any(x => bomb.GetSerialNumberLetters().Contains(x)))
					{
						modified = true;
						for(int j = 0; j < codes[i].Length; j++)
							if(codes[i][j] % 2 == 0)
								codes[i][j] = (codes[i][j] + 1) % 10;
							else
								codes[i][j]--;
					}
						
					if(bomb.GetOnIndicators().Count() == bomb.GetOffIndicators().Count())
					{
						modified = true;
						for(int j = 0; j < codes[i].Length; j++)
							codes[i][j] = 9 - codes[i][j];
					}

					if(!modified)
						codes[i] = codes[i].Reverse().ToArray();

        			Debug.LogFormat("[Module Listening #{0}] Red play button code (after modifications) is {1}.", moduleId, codes[i].Select(x => symbols[x]).Join(""));
					break;
				}
				case 1:
				{
					if(!(bomb.GetBatteryCount() >= 2))
						for(int j = 0; j < codes[i].Length; j++)
							codes[i][j] = (codes[i][j] + bomb.GetIndicators().Count()) % 10;

					if(!(bomb.GetIndicators().Count() >= 2))
						for(int j = 0; j < codes[i].Length; j++)
							codes[i][j] = (codes[i][j] + bomb.GetPortCount()) % 10;

					if(!(bomb.GetPortCount() >= 2))
						for(int j = 0; j < codes[i].Length; j++)
							codes[i][j] = (codes[i][j] + bomb.GetBatteryCount()) % 10;

					if(!(bomb.GetSerialNumberLetters().Count() == 3))
						for(int j = 0; j < codes[i].Length; j++)
							codes[i][j] = (codes[i][j] + bomb.GetSerialNumberNumbers().Sum()) % 10;
					
					Debug.LogFormat("[Module Listening #{0}] Green play button code (after modifications) is {1}.", moduleId, codes[i].Select(x => symbols[x]).Join(""));
					break;
				}
				case 2:
				{
					if(bomb.IsIndicatorOn(Indicator.BOB))
					{

					}
					else if(bomb.GetBatteryCount() == 5 && bomb.GetBatteryHolderCount() == 3)
					{
						for(int j = 0; j < codes[i].Length; j++)
							codes[i][j] = (codes[i][j] + 1) % 10;
					}
					else if(bomb.GetPortCount() == 0)
					{
						for(int j = 0; j < codes[i].Length; j++)
							codes[i][j] = (codes[i][j] + bomb.GetIndicators().Count()) % 10;
					}
					else if(!"13579".Any(x => bomb.GetSerialNumber().Contains(x)))
					{
						for(int j = 0; j < codes[i].Length; j++)
							if(codes[i][j] % 2 == 0)
								codes[i][j] /= 2;
							else
								codes[i][j] = (codes[i][j] * 2) % 10;
					}
					else
					{
						for(int j = 0; j < codes[i].Length; j++)
						{
							if("0123456789".Contains(bomb.GetSerialNumber()[j]))
								codes[i][j] = (codes[i][j] + bomb.GetSerialNumber()[j] - '0') % 10;
							else
								codes[i][j] = (codes[i][j] + bomb.GetSerialNumber()[j] - 'A' + 1) % 10;
						}
					}
					Debug.LogFormat("[Module Listening #{0}] Blue play button code (after modifications) is {1}.", moduleId, codes[i].Select(x => symbols[x]).Join(""));
					break;
				}
				case 3:
				{
					bool modified = false;

					if(moduleIndex.ToList().Exists(x => royalFlush.ToList().Exists(y => String.Compare(y, moduleNames[x], StringComparison.OrdinalIgnoreCase) == 0)))
					{
						modified = true;
						codes[i][0] = (codes[i][0] + 4) % 10;
						codes[i][1] = (codes[i][1] + 8) % 10;
						codes[i][2] = (codes[i][2] + 15) % 10;
						codes[i][3] = (codes[i][3] + 16) % 10;
						codes[i][4] = (codes[i][4] + 23) % 10;
					}

					if(moduleIndex.ToList().Exists(x => timwi.ToList().Exists(y => String.Compare(y, moduleNames[x], StringComparison.OrdinalIgnoreCase) == 0)))
					{
						modified = true;
						int concat = codes[i][0] * 10000 + codes[i][1] * 1000 + codes[i][2] * 100 + codes[i][3] * 10 + codes[i][4];
						
						concat = (concat % 47) % 10;
						for(int j = 0; j < codes[i].Length; j++)
							codes[i][j] = (codes[i][j] + concat) % 10;
					}

					if(moduleIndex.ToList().Exists(x => LeGeND.ToList().Exists(y => String.Compare(y, moduleNames[x], StringComparison.OrdinalIgnoreCase) == 0)) || moduleIndex.ToList().Exists(x => theThirdMan.ToList().Exists(y => String.Compare(y, moduleNames[x], StringComparison.OrdinalIgnoreCase) == 0)))
					{
						modified = true;
						if(bomb.GetPortCount() >= 4)
						{
							for(int j = 0; j < codes[i].Length; j++)
								codes[i][j] = (codes[i][j] + 4) % 10;
						}
						else if(bomb.GetBatteryCount(Battery.AA) == bomb.GetBatteryCount())
						{
							for(int j = 0; j < codes[i].Length; j++)
								if(codes[i][j] == 0)
									codes[i][j] = 7;
								else if(codes[i][j] == 7)
									codes[i][j] = 0;
								else if(codes[i][j] == 2)
									codes[i][j] = 9;
								else if(codes[i][j] == 9)
									codes[i][j] = 2;
								else if(codes[i][j] == 3)
									codes[i][j] = 8;
								else if(codes[i][j] == 8)
									codes[i][j] = 3;
						}
						else if("AEIOU".Any(x => bomb.GetSerialNumberLetters().Contains(x)))
						{
							for(int j = 0; j < codes[i].Length; j++)
								if(codes[i][j] % 2 == 0)
									codes[i][j] = (codes[i][j] + 1) % 10;
								else
									codes[i][j]--;
						}
						else if(bomb.GetOnIndicators().Count() == bomb.GetOffIndicators().Count())
						{
							for(int j = 0; j < codes[i].Length; j++)
								codes[i][j] = 9 - codes[i][j];
						}
						else
						{
							codes[i] = codes[i].Reverse().ToArray();
						}

						if(bomb.IsIndicatorOn(Indicator.BOB))
						{

						}
						else if(bomb.GetBatteryCount() == 5 && bomb.GetBatteryHolderCount() == 3)
						{
							for(int j = 0; j < codes[i].Length; j++)
								codes[i][j] = (codes[i][j] + 1) % 10;
						}
						else if(bomb.GetPortCount() == 0)
						{
							for(int j = 0; j < codes[i].Length; j++)
								codes[i][j] = (codes[i][j] + bomb.GetIndicators().Count()) % 10;
						}
						else if(!"13579".Any(x => bomb.GetSerialNumber().Contains(x)))
						{
							for(int j = 0; j < codes[i].Length; j++)
								if(codes[i][j] % 2 == 0)
									codes[i][j] /= 2;
								else
									codes[i][j] = (codes[i][j] * 2) % 10;
						}
						else
						{
							for(int j = 0; j < codes[i].Length; j++)
							{
								if("0123456789".Contains(bomb.GetSerialNumber()[j]))
									codes[i][j] = (codes[i][j] + bomb.GetSerialNumber()[j] - '0') % 10;
								else
									codes[i][j] = (codes[i][j] + bomb.GetSerialNumber()[j] - 'A' + 1) % 10;
							}
						}
					}

					if(!modified)
					{
						List<int> codeTmp = codes[i].ToList();
						codeTmp.Sort();
						codes[i] = codeTmp.ToArray();
					}

					Debug.LogFormat("[Module Listening #{0}] Yellow play button code (after modifications) is {1}.", moduleId, codes[i].Select(x => symbols[x]).Join(""));
					break;
				}
			}
		}
	}

	void CalcSubmission()
	{
		List<int> used = new List<int>();
		List<int> sub = new List<int>();

		for(int i = 0; i < moduleIndex.Length; i++)
			if(bomb.GetModuleNames().Exists(x => String.Compare(x, moduleNames[moduleIndex[i]], StringComparison.OrdinalIgnoreCase) == 0))
			{
				used.Add(i);
				for(int j = 0; j < codes[i].Length; j++)
					sub.Add(codes[i][j]);
				break;
			}

		if(used.Count() == 0)
		{
			used.Add(0);
			for(int i = 0; i < codes[0].Length; i++)
					sub.Add(codes[0][i]);
		}

		if((bomb.IsIndicatorPresent(Indicator.FRK) || bomb.IsIndicatorPresent(Indicator.TRN)) && !used.Contains(Array.IndexOf(btnColors, 0)))
		{
			used.Add(Array.IndexOf(btnColors, 0));
			for(int i = 0; i < codes[Array.IndexOf(btnColors, 0)].Length; i++)
					sub.Add(codes[Array.IndexOf(btnColors, 0)][i]);
		}
		else if(bomb.GetIndicators().Count() >= 3 && !used.Contains(Array.IndexOf(btnColors, 1)))
		{
			used.Add(Array.IndexOf(btnColors, 1));
			for(int i = 0; i < codes[Array.IndexOf(btnColors, 1)].Length; i++)
					sub.Add(codes[Array.IndexOf(btnColors, 1)][i]);
		}
		else if(bomb.GetOnIndicators().Count() > bomb.GetOffIndicators().Count() && !used.Contains(Array.IndexOf(btnColors, 3)))
		{
			used.Add(Array.IndexOf(btnColors, 3));
			for(int i = 0; i < codes[Array.IndexOf(btnColors, 3)].Length; i++)
					sub.Add(codes[Array.IndexOf(btnColors, 3)][i]);
		}
		else if(!used.Contains(Array.IndexOf(btnColors, 2)))
		{
			used.Add(Array.IndexOf(btnColors, 2));
			for(int i = 0; i < codes[Array.IndexOf(btnColors, 2)].Length; i++)
					sub.Add(codes[Array.IndexOf(btnColors, 2)][i]);
		}
		else
		{
			String cmp = "ZZZZ";
			int best = -1;
			for(int i = 0; i < btnColors.Length; i++)
			{
				if(used.Contains(i))
					continue;

				if(String.Compare(moduleNames[moduleIndex[i]], cmp, StringComparison.OrdinalIgnoreCase) < 0)
				{
					cmp = moduleNames[moduleIndex[i]];
					best = i;
				}
			}

			used.Add(best);
			for(int i = 0; i < codes[best].Length; i++)
					sub.Add(codes[best][i]);
		}

		int color1 = -1;
		int color2 = -1;

		for(int i = 0; i < btnColors.Length; i++)
		{
			if(!used.Contains(i))
				if(color1 == -1)
					color1 = btnColors[i];
				else
					color2 = btnColors[i];
		}

		if((color1 == 0 && color2 == 2) || (color1 == 2 && color2 == 0) || (color1 == 0 && color2 == 3))
		{
			used.Add(Array.IndexOf(btnColors, 0));
			for(int i = 0; i < codes[Array.IndexOf(btnColors, 0)].Length; i++)
					sub.Add(codes[Array.IndexOf(btnColors, 0)][i]);
		}
		else if((color1 == 0 && color2 == 1) || (color1 == 1 && color2 == 0) || (color1 == 1 && color2 == 2))
		{
			used.Add(Array.IndexOf(btnColors, 1));
			for(int i = 0; i < codes[Array.IndexOf(btnColors, 1)].Length; i++)
					sub.Add(codes[Array.IndexOf(btnColors, 1)][i]);
		}
		else if((color1 == 2 && color2 == 1) || (color1 == 2 && color2 == 3) || (color1 == 3 && color2 == 2))
		{
			used.Add(Array.IndexOf(btnColors, 2));
			for(int i = 0; i < codes[Array.IndexOf(btnColors, 2)].Length; i++)
					sub.Add(codes[Array.IndexOf(btnColors, 2)][i]);
		}
		else
		{
			used.Add(Array.IndexOf(btnColors, 3));
			for(int i = 0; i < codes[Array.IndexOf(btnColors, 3)].Length; i++)
					sub.Add(codes[Array.IndexOf(btnColors, 3)][i]);
		}

		for(int i = 0; i < btnColors.Length; i++)
		{
			if(!used.Contains(i))
			{
				used.Add(i);
				for(int j = 0; j < codes[i].Length; j++)
					sub.Add(codes[i][j]);
			}
		}

		answer = sub.ToArray();

        Debug.LogFormat("[Module Listening #{0}] Code submission order is [ {1} ].", moduleId, used.Select(x => buttonMats[btnColors[x]].name).Join(", "));
        Debug.LogFormat("[Module Listening #{0}] Final submission code is {1}.", moduleId, used.Select(x => codes[x].Select(y => symbols[y]).Join("")).Join("  "));
	}
}
