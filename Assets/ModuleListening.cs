using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;
using rnd = UnityEngine.Random;
using System.Text.RegularExpressions;

public class ModuleListening : MonoBehaviour 
{
	public KMBombInfo bomb;
	public KMAudio mAudio;
	public KMBombModule modSelf;

	readonly string symbols = "!@%^(_|\\\'<";

	public AudioClip[] AMistake,
		Bartending, Battleship, BenedictCumberbatch, BlackHole, Blockbusters, BobBarks, BootTooBig, BritishSlang, BrokenButtons, BurglarAlarm,
		CheapCheckout, ChordQualities, ChristmasPresents, ColoredKeys, ColoredSquares, CookieJars, Creation, CrystalMaze, Cube,
		DoubleExpert, DoubleOh,
		EncryptedEquations, EuropeanTravel,
		FastMath, ForgetEnigma, ForgetMeNow, FreeParking, Friendship,
		GadgetronVendor, GraffitiNumbers, Gridlock, GuitarChords,
		Hexamaze, HiddenColors, Hieroglyphics, Hogwarts, Hypercube,
		Instructions,
		JackOLantern, JewelVault,
		Kudosudoku,
		Labyrinth, Laundry, LEDMath, Lightspeed, LondonUnderground, LuckyDice,
		Maintenance, Mazematics, MegaMan2, Minesweeper, MortalKombat,
		Necronomicon, Neutralization, Nonograms, NumberCipher, NumberNimbleness,
		OnlyConnect,
		Painting, PartialDerivatives, PerspectivePegs,
		QuizzBuzz, Qwirkle,
		Rhythms, RPSLS,
		SchlagDenBomb, SevenDeadlySins, ShapesAndBombs, SillySlots, SimonSamples, SimonSelects, SimonSends, SimonSimons, SimonSings, SimonStores, SimonsStages, Sink, SonicTheHedgehog, Souvenir, Sphere, StreetFighter, Sun, Swan, Synchronization,
		Tangrams, TashaSqueals, Tennis, TreasureHunt, TurtleRobot,
		UnfairCipher,
		Valves, VisualImpairment,
		WasteManagement, Wavetapping, Wire, WordSearch,
		XRay, X01,
		Yahtzee,
		Zoni;

	public AudioSource sound;
	AudioClip[][] audioLibrary;
	string[] moduleNames = {
		"A Mistake", "Bartending", "Battleship", "Benedict Cumberbatch", "Black Hole", "Blockbusters", "Bob Barks", "Boot Too Big", "British Slang", "Broken Buttons",
		"Burglar Alarm", "Cheap Checkout", "Chord Qualities", "Christmas Presents", "Colored Keys", "Colored Squares","Cookie Jars", "Creation", "The Crystal Maze", "The Cube",
		"Double Expert", "Double-Oh", "Encrypted Equations", "European Travel","Fast Math", "Forget Enigma", "Forget Me Now", "Free Parking", "Friendship", "Gadgetron Vendor",
		"Graffiti Numbers", "Gridlock", "Guitar Chords", "Hexamaze", "Hidden Colors", "Hieroglyphics", "Hogwarts", "The Hypercube", "Instructions", "The Jack-O’-Lantern",
		"The Jewel Vault", "Kudosudoku", "The Labyrinth", "Laundry", "LED Math", "Lightspeed", "The London Underground", "Lucky Dice", "Maintenance", "Mazematics",
		"Mega Man 2", "Minesweeper", "Mortal Kombat", "The Necronomicon", "Neutralization", "The Number Cipher", "Number Nimbleness", "Only Connect", "Painting", "Partial Derivatives",
		"Perspective Pegs", "Quiz Buzz", "Qwirkle", "Rhythms", "Rock-Paper-Scissors-L.-Sp.", "Schlag den Bomb", "Seven Deadly Sins", "Shapes and Bombs", "Silly Slots", "Simon Samples",
		"Simon Selects", "Simon Sends", "Simon Simons", "Simon Sings", "Simon Stores", "Simon's Stages", "Sink","Sonic The Hedgehog", "Souvenir", "The Sphere",
		"Street Fighter", "The Sun", "The Swan", "Synchronization", "Tangrams", "Tasha Squeals", "Tennis", "Treasure Hunt", "Turtle Robot", "Unfair Cipher",
		"Valves", "Visual Impairment", "Waste Management","Wavetapping", "The Wire", "Word Search", "X-Ray", "X01", "Yahtzee", "Zoni",
	};
	string[] moduleIds = {
		"MistakeModule","BartendingModule","BattleshipModule","benedictCumberbatch","BlackHoleModule","blockbusters","ksmBobBarks","bootTooBig","britishSlang","BrokenButtonsModule",
		"burglarAlarm","CheapCheckoutModule","ChordQualities","christmasPresents","lgndColoredKeys","ColoredSquaresModule","cookieJars","CreationModule","crystalMaze","cube",
		"doubleExpert","DoubleOhModule","EncryptedEquationsModule","europeanTravel","fastMath","forgetEnigma","ForgetMeNow","freeParking","FriendshipModule","lgndGadgetronVendor",
		"graffitiNumbers","GridlockModule","guitarChords","HexamazeModule","lgndHiddenColors","hieroglyphics","HogwartsModule","TheHypercubeModule","instructions","jackOLantern",
		"jewelVault","KudosudokuModule","labyrinth","Laundry","lgndLEDMath","lightspeed","londonUnderground","luckyDice","maintenance","mazematics",
		"megaMan2","MinesweeperModule","mortalKombat","necronomicon","neutralization","numberCipher","numberNimbleness","OnlyConnectModule","Painting","partialDerivatives",
		"spwizPerspectivePegs","quizBuzz","qwirkle","MusicRhythms","RockPaperScissorsLizardSpockModule","qSchlagDenBomb","sevenDeadlySins","ShapesBombs","SillySlots","simonSamples",
		"simonSelectsModule","SimonSendsModule","simonSimons","SimonSingsModule","simonStores","simonsStages","Sink","sonic","SouvenirModule","sphere",
		"streetFighter","sun","theSwan","SynchronizationModule","Tangrams","tashaSqueals","TennisModule","treasureHunt","turtleRobot","unfairCipher",
		"valves","visual_impairment","wastemanagement","Wavetapping","wire","WordSearchModule","XRayModule","X01","YahtzeeModule","lgndZoni",
	};
	string[] moduleCodesAll = new string[]
		{
			"_|\\!(", "^\\^|<", "(!(%(", "|(@^%", "'%<|^", "@(!(_", "%@|'^", "<|!^\\", "|^@_(", "!|(|_",
			"_@<(<", "\\(!<%", "(\\^%^" ,"_(@<^", "!@^(!", "%<|((", "(\\!_%", "<<%%(", "''|(^", "|@|'^",
			"!@_^!", "_<'\\'", "|!(|\\", "%!^|(", "_<_!%", "!@!^_", "%^!^^", "^!<\\\\", "<''\\(", "(_%!|",
			"\\_@<%", "%\\'(\\", "<!'|!", "'(^<!", "_'%\\!", "!'%!(", "^(%|\\", "^!!(\\", "!^<%(", "'@\\\\|",
			"|(@'^", "_|%<|", "_<_|_", "@('('", "@\\!^_", "'_!^'", "@%<'_", "|<(\\@", "|'||<", "'(!%'",
			"!(\\(_","'(%@_","|''\\|","%\\\\<!","(^_<!","(!^'\\","@'!^^","|(<@_","^!(!'",
			"''!%^","@^@|_","'_!%^","^^^@(","<|!%%","!\\((<","|''%\\","('\\!'","^@@(^","^__(_",
			"(_%@!","^%@!<","@<___","|(@@!","_|^||","!^@'_","'!_(%","!<|@!","^|<!^","^<<!%",
			"@(\\\\\\","^\\|^^","^<!|%","'!@@|","%@_(@","!<!_<","<|@(<","\\(!!(","!@|!!","|^<<_","_@''_",
			"_|_!!","!_\\!|","<_<^!","_!<^(","%^|_!","''!'!","'^_'\\","!'<\\|","!(%|(","%(%(_",
		};

	string[] royalFlushModNames = { "Benedict Cumberbatch", "Blockbusters", "British Slang", "Christmas Presents", "The Crystal Maze", "The Cube", "European Travel", "Free Parking", "Graffiti Numbers", "Guitar Chords", "Hieroglyphics", "The Jack-O'-Lantern", "The Jewel Vault", "The Labyrinth", "Lightspeed", "The London Underground", "Maintenance", "Mortal Kombat", "The Number Cipher", "Simon's Stages", "Sonic the Hedgehog", "The Sphere", "Street Fighter", "The Sun", "The Swan", "The Wire" };
	string[] timwiModNames = { "Battleship"," Black Hole", "Colored Squares", "Double-Oh", "Friendship", "Gridlock", "Hexamaze", "Hogwarts"," The Hypercube", "Kudosudoku", "Only Connect", "Rock-Paper-Scissors-L.-Sp.", "Simon Sends", "Simon Sings", "Souvenir", "Tennis", "Word Search", "X-Ray", "Yahtzee" };
	string[] LeGeNDModNames = { "Colored Keys", "Fast Math", "Gadgetron Vendor", "Hidden Colors", "The Jack-O'-Lantern", "LED Math", "Zoni" };
	string[] theThirdManModNames = { "Boot Too Big", "Double Expert", "Lucky Dice", "The Necronomicon", "Qwirkle", "Seven Deadly Sins", "Treasure Hunt" };

	//Logging
	static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

	public KMSelectable[] playBtns;
	public KMSelectable[] symbolBtns;


	public Material[] buttonMats;
	public Material[] lightMats;

	public GameObject cassette;
	public Material[] cassetteMats;

	public Renderer[] correctLights;
	public MeshRenderer backing;
	public Light lightTransform;

	int[] btnColors;
	int[] moduleIndex = new int[4];
	int[] soundIndex = new int[4];
	string[] codeStrings = new string[4];

	string[] buttonColors = { "red", "green", "blue", "yellow" };
	string[] moduleSelectedNames = new string[4];
	string answerString;
	string inputString;

	List<int> orderSubmit = new List<int>();

	bool hardModeEnabled = false, interactable = true, canEnterHardMode = true, canTPEnterHardMode; // TP handling only atm, may try to add config down the line

	ModuleListeningSettings localSettings = new ModuleListeningSettings();
	int PPAValue;
	List<int> input = new List<int>();

	public List<string> grabModuleSoundsAll()
	{// Grabs the names of the modules referenced by this module from each mod index from left to right.
		List<string> output = new List<string>();
		foreach (int modIdx in moduleIndex)
			output.Add(moduleNames[modIdx]);
		return output;
	}


	void Awake()
	{
		moduleId = moduleIdCounter++;
		try
		{
			ModConfig<ModuleListeningSettings> modConfig = new ModConfig<ModuleListeningSettings>("ModuleListeningSettings");
			localSettings = modConfig.Settings;

			hardModeEnabled = localSettings.enableHardMode;
			canTPEnterHardMode = !localSettings.noTPHardMode;
			PPAValue = localSettings.TPRewardBonus;
		}
		catch
		{
			Debug.LogWarningFormat("[Module Listening #{0}] Warning! Settings for Module Listening do not work as intended! Using default settings instead.",moduleId);
			hardModeEnabled = false;
			canTPEnterHardMode = true;
			PPAValue = 5;
		}
	}

	void PressPlay(int btn)
	{
		playBtns[btn].AddInteractionPunch(.5f);
		canEnterHardMode = false;
		cassette.GetComponentInChildren<Renderer>().material = cassetteMats[btnColors[btn]];
		if (moduleSolved)
		{
			mAudio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonRelease, transform);
			return;
		}
		inputString = "";
		sound.clip = audioLibrary[moduleIndex[btn]][soundIndex[btn]];
		sound.Play();
		input.Clear();
		foreach (Renderer r in correctLights)
			r.material = lightMats[2];
	}

	void PressSymbol(int btn)
	{
		mAudio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
		symbolBtns[btn].AddInteractionPunch(.5f);

		if(moduleSolved)
			return;

		inputString += symbols[btn];

		if(inputString.Length >= 20)
		{
			if(inputString.ToCharArray().SequenceEqual(answerString.ToCharArray()))
			{
				foreach(Renderer r in correctLights)
					r.material = lightMats[0];
				mAudio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.CorrectChime, transform);
        		Debug.LogFormat("[Module Listening #{0}] Entire input is correct. Module solved.", moduleId);
				modSelf.HandlePass();
				moduleSolved = true;
			}
			else
			{
				bool[] lightStatus = { true, true, true, true };
				for (int x = 0; x < lightStatus.Length; x++)
					lightStatus[Array.IndexOf(btnColors,orderSubmit[x])] = answerString.Substring(x * 5, 5).SequenceEqual(inputString.Substring(x * 5, 5));

				StartCoroutine(ShowCorrectLights(lightStatus));

        		Debug.LogFormat("[Module Listening #{0}] Strike! Received input: [ {1} ].", moduleId, inputString.ToCharArray().Join());
				modSelf.HandleStrike();
				inputString = "";
			}
		}
		else if(inputString.Length % 5 == 0)
		{
			mAudio.PlaySoundAtTransform("ding", transform);
            for (int i = 0; i < inputString.Length / 5; i++)
            {
                Renderer r = correctLights[i];
                r.material = lightMats[3];
            }
        }
	}

	void Start () 
	{
		for (int x = 0; x < playBtns.Length; x++)
		{
			int y = x;
			playBtns[x].OnInteract += delegate { PressPlay(y); return false; };
		}
		for (int x = 0; x < symbolBtns.Length; x++)
		{
			int y = x;
			symbolBtns[x].OnInteract += delegate { PressSymbol(y); return false; };
		}
		float scale = transform.lossyScale.x;
		lightTransform.range *= scale;
		LoadAudioLibrary();
		SetUpButtons();
		if (hardModeEnabled) {
			CalcModifications();
			backing.material.color = Color.red;
		}
		else
        {
			backing.material.color = Color.white;
        }
		CalcSubmission();
	}

	void LoadAudioLibrary()
	{
		if (audioLibrary != null) return;
		audioLibrary = new AudioClip[][] {
			AMistake, Bartending, Battleship,
			BenedictCumberbatch, BlackHole, Blockbusters, BobBarks,
			BootTooBig, BritishSlang, BrokenButtons, BurglarAlarm,
			CheapCheckout, ChordQualities, ChristmasPresents,
			ColoredKeys, ColoredSquares, CookieJars,
			Creation, CrystalMaze, Cube, DoubleExpert,
			DoubleOh, EncryptedEquations, EuropeanTravel,
			FastMath, ForgetEnigma, ForgetMeNow, FreeParking,
			Friendship, GadgetronVendor, GraffitiNumbers,
			Gridlock, GuitarChords, Hexamaze, HiddenColors,
			Hieroglyphics, Hogwarts, Hypercube, Instructions,
			JackOLantern, JewelVault, Kudosudoku,
			Labyrinth, Laundry, LEDMath, Lightspeed, LondonUnderground,
			LuckyDice, Maintenance, Mazematics, MegaMan2,
			Minesweeper, MortalKombat, Necronomicon,
			Neutralization, NumberCipher, NumberNimbleness, OnlyConnect,
			Painting, PartialDerivatives,
			PerspectivePegs, QuizzBuzz, Qwirkle,
			Rhythms, RPSLS, SchlagDenBomb, SevenDeadlySins,
			ShapesAndBombs, SillySlots,
			SimonSamples, SimonSelects, SimonSends, SimonSimons,
			SimonSings,SimonStores,SimonsStages,Sink,
			SonicTheHedgehog,Souvenir,Sphere,StreetFighter,
			Sun,Swan,Synchronization,Tangrams,
			TashaSqueals,Tennis,TreasureHunt,TurtleRobot,
			UnfairCipher,Valves,VisualImpairment,WasteManagement,
			Wavetapping,Wire,WordSearch,XRay,
			X01,Yahtzee,Zoni,
		};
	}
	
	void SetUpButtons()
	{
		btnColors = Enumerable.Range(0, 4).OrderBy(x => x = rnd.Range(int.MinValue, int.MaxValue)).ToArray();

		for(int i = 0; i < btnColors.Length; i++)
			playBtns[i].gameObject.transform.GetComponentInChildren<Renderer>().material = buttonMats[btnColors[i]];

		cassette.GetComponentInChildren<Renderer>().material = cassetteMats[btnColors[0]];

        Debug.LogFormat("[Module Listening #{0}] Play button colors: [ {1} ].", moduleId, btnColors.Select(x => buttonColors[x]).Join(", "));;
	
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


        	Debug.LogFormat("[Module Listening #{0}] The {1} button plays a sound from the module \"{2}.\"", moduleId, buttonColors[btnColors[i]], moduleNames[moduleIndex[i]]);
			codeStrings[i] = moduleCodesAll[moduleIndex[i]];
			moduleSelectedNames[i] = moduleNames[moduleIndex[i]];
			Debug.LogFormat("[Module Listening #{0}] The code from the {1} button{3} is [ {2} ].", moduleId, buttonColors[btnColors[i]], moduleCodesAll[r].ToCharArray().Join(), hardModeEnabled ? " before modification" : "");
		}
	}

	//Hard Mode Only
	void CalcModifications()
	{
		for(int i = 0; i < codeStrings.Length; i++)
		{
			List<int> curModCode = new List<int>();
			foreach (char s in codeStrings[i])
			{
				curModCode.Add(symbols.IndexOf(s));
			}
			switch (btnColors[i])
			{
				case 0:
				{
						Debug.LogFormat("[Module Listening #{0}] Red play modifications:", moduleId);
						bool modified = false;

						if (bomb.GetPortCount() >= 4)
						{
							modified = true;
							Debug.LogFormat("[Module Listening #{0}] The bomb has 4 or more ports.", moduleId);
							for (int j = 0; j < curModCode.Count; j++)
								curModCode[j] = (curModCode[j] + 4) % 10;
							
						}
						
						if (bomb.GetBatteryCount(Battery.AA) == bomb.GetBatteryCount())
						{
							modified = true;
							Debug.LogFormat("[Module Listening #{0}] The bomb consists of only AA batteries or no batteries.", moduleId);
							for (int j = 0; j < curModCode.Count; j++)
							switch (curModCode[j])
								{
									case 0:
										curModCode[j] = 7;
										break;
									case 7:
										curModCode[j] = 0;
										break;
									case 2:
										curModCode[j] = 9;
										break;
									case 9:
										curModCode[j] = 2;
										break;
									case 3:
										curModCode[j] = 8;
										break;
									case 8:
										curModCode[j] = 3;
										break;
								}
						}
						
						if ("AEIOU".Any(x => bomb.GetSerialNumberLetters().Contains(x)))
						{
							modified = true;
							Debug.LogFormat("[Module Listening #{0}] The serial number contains a vowel.", moduleId);
							for (int j = 0; j < curModCode.Count; j++)
								if(curModCode[j] % 2 == 0)
									curModCode[j]++;
								else
									curModCode[j]--;
						}

						if (bomb.GetOnIndicators().Count() == bomb.GetOffIndicators().Count())
						{
							Debug.LogFormat("[Module Listening #{0}] There is an equal number of lit and unlit indicators", moduleId);
							modified = true;
							for(int j = 0; j < curModCode.Count; j++)
								curModCode[j] = 9 - curModCode[j];
						}

						if (!modified)
						{
							Debug.LogFormat("[Module Listening #{0}] None of the above conditions were met on the table.", moduleId);
							curModCode.Reverse();
						}

        			Debug.LogFormat("[Module Listening #{0}] Red play button code after modifications: [ {1} ]", moduleId, curModCode.Select(x => symbols[x]).Join());
					break;
				}
				case 1:
				{
						Debug.LogFormat("[Module Listening #{0}] Green play modifications:", moduleId);
						if (bomb.GetBatteryCount() < 2)
						{
							Debug.LogFormat("[Module Listening #{0}] The bomb does not have 2 or more batteries.", moduleId);
							for (int j = 0; j < curModCode.Count; j++)
								curModCode[j] = (curModCode[j] + bomb.GetIndicators().Count()) % 10;
						}


						if (bomb.GetIndicators().Count() < 2)
						{
							Debug.LogFormat("[Module Listening #{0}] The bomb does not have 2 or more indicators.", moduleId);
							for (int j = 0; j < curModCode.Count; j++)
								curModCode[j] = (curModCode[j] + bomb.GetPortCount()) % 10;
						}
						if (bomb.GetPortCount() < 2)
						{
							Debug.LogFormat("[Module Listening #{0}] The bomb does not have 2 or more ports.", moduleId);
							for (int j = 0; j < curModCode.Count; j++)
								curModCode[j] = (curModCode[j] + bomb.GetBatteryCount()) % 10;
						}
						if (bomb.GetSerialNumberLetters().Count() != 3)
						{
							Debug.LogFormat("[Module Listening #{0}] The serial number does not have exactly 3 letters.", moduleId);
							for (int j = 0; j < curModCode.Count; j++)
								curModCode[j] = (curModCode[j] + bomb.GetSerialNumberNumbers().Sum()) % 10;
						}
						Debug.LogFormat("[Module Listening #{0}] Green play button code after modifications: [ {1} ]", moduleId, curModCode.Select(x => symbols[x]).Join());
					break;
				}
				case 2:
				{
						Debug.LogFormat("[Module Listening #{0}] Blue play modifications:", moduleId);
						if (!bomb.IsIndicatorOn(Indicator.BOB))
						{
							if (bomb.GetBatteryCount() == 5 && bomb.GetBatteryHolderCount() == 3)
							{
								Debug.LogFormat("[Module Listening #{0}] There are 5 batteries in 3 holders.", moduleId);
								for (int j = 0; j < curModCode.Count; j++)
									curModCode[j] = (curModCode[j] + 1) % 10;
							}
							else if (bomb.GetPortCount() == 0)
							{
								Debug.LogFormat("[Module Listening #{0}] There are no ports.", moduleId);
								for (int j = 0; j < curModCode.Count; j++)
									curModCode[j] = (curModCode[j] + bomb.GetIndicators().Count()) % 10;
							}
							else if (!"13579".Any(x => bomb.GetSerialNumber().Contains(x)))
							{
								Debug.LogFormat("[Module Listening #{0}] There are no odd digits in the serial number.", moduleId);
								for (int j = 0; j < curModCode.Count; j++)
									if (curModCode[j] % 2 == 0)
										curModCode[j] /= 2;
									else
										curModCode[j] = curModCode[j] * 2 % 10;
							}
							else
							{
								string serialNo = bomb.GetSerialNumber();
								Debug.LogFormat("[Module Listening #{0}] None of the above applied.", moduleId);
								for (int j = 0; j < curModCode.Count; j++)
								{
									if ("0123456789".Contains(serialNo[j]))
										curModCode[j] = (curModCode[j] + serialNo[j] - '0') % 10;
									else
										curModCode[j] = (curModCode[j] + serialNo[j] - 'A' + 1) % 10;
								}
							}
						}
						else
						{
							Debug.LogFormat("[Module Listening #{0}] There is a lit BOB indicator.", moduleId);
						}
						Debug.LogFormat("[Module Listening #{0}] Blue play button code after modifications: [ {1} ]", moduleId, curModCode.Select(x => symbols[x]).Join());
					break;
				}
				case 3:
				{
						Debug.LogFormat("[Module Listening #{0}] Yellow play modifications:", moduleId);
						if (moduleIndex.ToList().Exists(x => LeGeNDModNames.ToList().Exists(y => string.Compare(y, moduleNames[x], StringComparison.OrdinalIgnoreCase) == 0)) || moduleIndex.ToList().Exists(x => theThirdManModNames.ToList().Exists(y => string.Compare(y, moduleNames[x], StringComparison.OrdinalIgnoreCase) == 0)))
						{
							Debug.LogFormat("[Module Listening #{0}] At least 1 sound comes from a module made by LeGeND or TheThirdMan.", moduleId);
							// Red Modification
							if (bomb.GetPortCount() >= 4)
							{
								Debug.LogFormat("[Module Listening #{0}] The bomb has 4 or more ports.", moduleId);
								for (int j = 0; j < curModCode.Count; j++)
									curModCode[j] = (curModCode[j] + 4) % 10;

							}
							else if (bomb.GetBatteryCount(Battery.AA) == bomb.GetBatteryCount())
							{
								Debug.LogFormat("[Module Listening #{0}] The bomb consists of only AA batteries.", moduleId);
								for (int j = 0; j < curModCode.Count; j++)
									switch (curModCode[j])
									{
										case 0:
											curModCode[j] = 7;
											break;
										case 7:
											curModCode[j] = 0;
											break;
										case 2:
											curModCode[j] = 9;
											break;
										case 9:
											curModCode[j] = 2;
											break;
										case 3:
											curModCode[j] = 8;
											break;
										case 8:
											curModCode[j] = 3;
											break;
									}
							}
							else if ("AEIOU".Any(x => bomb.GetSerialNumberLetters().Contains(x)))
							{
								Debug.LogFormat("[Module Listening #{0}] The serial number contains a vowel.", moduleId);
								for (int j = 0; j < curModCode.Count; j++)
									if (curModCode[j] % 2 == 0)
										curModCode[j]++;
									else
										curModCode[j]--;
							}
							else if (bomb.GetOnIndicators().Count() == bomb.GetOffIndicators().Count())
							{
								Debug.LogFormat("[Module Listening #{0}] There is an equal number of lit and unlit indicators", moduleId);
								for (int j = 0; j < curModCode.Count; j++)
									curModCode[j] = 9 - curModCode[j];
							}
							else
							{
								Debug.LogFormat("[Module Listening #{0}] None of the above conditions were met on the table.", moduleId);
								curModCode.Reverse();
							}
							// Blue Modification
							if (!bomb.IsIndicatorOn(Indicator.BOB))
							{
								if (bomb.GetBatteryCount() == 5 && bomb.GetBatteryHolderCount() == 3)
								{
									Debug.LogFormat("[Module Listening #{0}] There are 5 batteries in 3 holders.", moduleId);
									for (int j = 0; j < curModCode.Count; j++)
										curModCode[j] = (curModCode[j] + 1) % 10;
								}
								else if (bomb.GetPortCount() == 0)
								{
									Debug.LogFormat("[Module Listening #{0}] There are no ports.", moduleId);
									for (int j = 0; j < curModCode.Count; j++)
										curModCode[j] = (curModCode[j] + bomb.GetIndicators().Count()) % 10;
								}
								else if (!"13579".Any(x => bomb.GetSerialNumber().Contains(x)))
								{
									Debug.LogFormat("[Module Listening #{0}] There are no odd digits in the serial number.", moduleId);
									for (int j = 0; j < curModCode.Count; j++)
										if (curModCode[j] % 2 == 0)
											curModCode[j] /= 2;
										else
											curModCode[j] = curModCode[j] * 2 % 10;
								}
								else
								{
									string serialNo = bomb.GetSerialNumber();
									Debug.LogFormat("[Module Listening #{0}] None of the above applied.", moduleId);
									for (int j = 0; j < curModCode.Count; j++)
									{
										if ("0123456789".Contains(serialNo[j]))
											curModCode[j] = (curModCode[j] + serialNo[j] - '0') % 10;
										else
											curModCode[j] = (curModCode[j] + serialNo[j] - 'A' + 1) % 10;
									}
								}
							}
							else
							{
								Debug.LogFormat("[Module Listening #{0}] There is a lit BOB indicator.", moduleId);
							}
						}
					else if (moduleIndex.ToList().Exists(x => timwiModNames.ToList().Exists(y => string.Compare(y, moduleNames[x], StringComparison.OrdinalIgnoreCase) == 0)))
					{
						Debug.LogFormat("[Module Listening #{0}] At least 1 sound comes from a module made by Timwi.", moduleId);
						int concat = int.Parse(curModCode.Join("")) % 47 % 10;
						for (int j = 0; j < curModCode.Count; j++)
								curModCode[j] = (curModCode[j] + concat) % 10;
					}
					else if (moduleIndex.ToList().Exists(x => royalFlushModNames.ToList().Exists(y => string.Compare(y, moduleNames[x], StringComparison.OrdinalIgnoreCase) == 0)))
					{
							Debug.LogFormat("[Module Listening #{0}] At least 1 sound comes from a module made by Royal_Flu$h.", moduleId);
							int[] swanCodes = { 4, 8, 15, 16, 23, 42 };
							for (int p = 0; p < curModCode.Count; p++)
							{
								curModCode[p] = (curModCode[p] + swanCodes[p]) % 10;
							}
					}
					else
					{
							Debug.LogFormat("[Module Listening #{0}] None of the sounds come from a module made by Royal_Flu$h, Timwi, TheThirdMan, or LeGeND.", moduleId);
							curModCode.Sort();
					}

					Debug.LogFormat("[Module Listening #{0}] Yellow play button code after modifications: [ {1} ]", moduleId, curModCode.Select(x => symbols[x]).Join());
					break;
				}
			}
			string codeModified = "";
			foreach (int x in curModCode)
				codeModified += symbols[x];
			codeStrings[i] = codeModified;
		}
	}

	void CalcSubmission()
	{
		List<int> unused = new List<int>(btnColors);
		List<string> submitList = new List<string>();
		List<string> bombModIDs = bomb.GetModuleIDs();
		answerString = "";
		Debug.LogFormat("[Module Listening #{0}] Submission Order: ", moduleId);
		for (int i = 0; i < moduleIndex.Length; i++)
			if (bombModIDs.Contains(moduleIds[moduleIndex[i]]))
			{
				unused.RemoveAt(i);
				submitList.Add(buttonColors[btnColors[i]]);
				Debug.LogFormat("[Module Listening #{0}] The {1} play button is the left-most button that have sounds from the module that is present on the bomb.", moduleId, buttonColors[btnColors[i]]);
				answerString += codeStrings[i];

				break;
			}
		
		if (unused.Count() == 4)
		{
			submitList.Add(buttonColors[unused[0]]);
			unused.RemoveAt(0);
			Debug.LogFormat("[Module Listening #{0}] No play buttons contain a sound from a module on the bomb. The left-most play button used is {1}.", moduleId, buttonColors[btnColors[0]]);
			answerString += codeStrings[0];
		}
		//Debug.Log(unused.Join());   // Log the unused list up to the end of the 1st part.
		if ((bomb.IsIndicatorPresent(Indicator.FRK) || bomb.IsIndicatorPresent(Indicator.TRN)) && unused.Contains(0))
		{
			Debug.LogFormat("[Module Listening #{0}] There is a TRN/FRK indicator and red is not used yet.", moduleId);
			submitList.Add(buttonColors[0]);
			unused.Remove(0);
			answerString += codeStrings[Array.IndexOf(btnColors, 0)];
		}
		else if (bomb.GetIndicators().Count() >= 3 && unused.Contains(1))
		{
			Debug.LogFormat("[Module Listening #{0}] There are at least 3 indicators and green is not used yet.", moduleId);
			unused.Remove(1);
			submitList.Add(buttonColors[1]);
			answerString += codeStrings[Array.IndexOf(btnColors, 1)];
		}
		else if (bomb.GetOnIndicators().Count() > bomb.GetOffIndicators().Count() && unused.Contains(3))
		{
			Debug.LogFormat("[Module Listening #{0}] There are more lit indicators than unlit indicators and yellow is not used yet.", moduleId);
			unused.Remove(3);
			submitList.Add(buttonColors[3]);
			answerString += codeStrings[Array.IndexOf(btnColors, 3)];
		}
		else if(unused.Contains(2))
		{
			Debug.LogFormat("[Module Listening #{0}] Blue is not used yet.", moduleId);
			unused.Remove(2);
			submitList.Add(buttonColors[2]);
			answerString += codeStrings[Array.IndexOf(btnColors, 2)];
		}
		else
		{

			string cmp = "";
			int best = -1;
			for (int i = 0; i < unused.Count; i++)
			{
				string ModNameDisplay = moduleNames[moduleIndex[Array.IndexOf(btnColors, unused[i])]].Replace("The ", "");
				//Debug.Log(ModNameDisplay);
				if (cmp.Length == 0 || string.Compare(ModNameDisplay, cmp, StringComparison.OrdinalIgnoreCase) < 0)
				{
					//Debug.Log(ModNameDisplay + " < " + cmp);
					cmp = ModNameDisplay;
					best = unused[i];
				}
			}
			int idxBest = Array.IndexOf(btnColors, best);
			Debug.LogFormat("[Module Listening #{0}] No available colors from the provided conditions, the {1} play button has the module that comes first alphabetically.", moduleId, buttonColors[btnColors[idxBest]]);
			unused.Remove(best);
			submitList.Add(buttonColors[btnColors[idxBest]]);
			answerString += codeStrings[idxBest];
		}
		//Debug.Log(unused.Join()); // Log the unused list up to the end of the 2nd part.
		int color1 = unused[0];
		int color2 = unused[1];
		Debug.LogFormat("[Module Listening #{0}] The {1} play button is the left-most unused. The {2} play button is the right-most unused.", moduleId, buttonColors[color1], buttonColors[color2]);

		int[,] colorTable = {
			{ -1, 1, 0, 0 },
			{ 1, -1, 1, 3 },
			{ 0, 2, -1, 2 },
			{ 3, 3, 2, -1 },
		};
		int desiredColor = colorTable[color1, color2];

		unused.Remove(desiredColor);
		submitList.Add(buttonColors[desiredColor]);
		Debug.LogFormat("[Module Listening #{0}] The table dictates the desired color to use for the Code 3 is {1}", moduleId, buttonColors[desiredColor]);
		answerString += codeStrings[Array.IndexOf(btnColors, desiredColor)];

		Debug.LogFormat("[Module Listening #{0}] This leaves the remaining unused color to be {1} for Code 4.", moduleId, buttonColors[unused[0]]);
		submitList.Add(buttonColors[unused[0]]);
		answerString += codeStrings[Array.IndexOf(btnColors,unused[0])];

		foreach (string clr in submitList)
		{
			orderSubmit.Add(buttonColors.ToList().IndexOf(clr));
		}

        Debug.LogFormat("[Module Listening #{0}] Code submission order: [ {1} ]", moduleId, submitList.Join(", "));
        Debug.LogFormat("[Module Listening #{0}] Final submission code: [ {1} ]", moduleId, answerString.ToCharArray().Join());
		interactable = true;
	}

	IEnumerator ShowCorrectLights(bool[] status)
	{
		for(int i = 0; i < status.Length; i++)
		{
			correctLights[i].material = status[i] ? lightMats[0] : lightMats[1];
		}

		yield return new WaitForSeconds(2f);

		for(int i = 0; i < status.Length; i++)
			correctLights[i].material = lightMats[2];
	}


	public class ModuleListeningSettings
	{
		public bool enableHardMode = false;
		public bool noTPHardMode = false;
		public int TPRewardBonus = 5;
	}

    //twitch plays
/*    private bool cmdIsValid(string cmd)
    {
        char[] valids = { '!', '@', '%', '^', '(', '_', '|', '\\', '\'', '<' };
        if (cmd.Length == 20)
        {
            foreach (char c in cmd)
            {
                if (!valids.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }*/

#pragma warning disable 414
    private readonly string TwitchHelpMessage = "To play the given tapes: \"!{0} play <color>\" Acceptable color options are red, blue, green, yellow. " +
		"To play all the tapes from left to right \"!{0} play all\"\n" +
		"To submit the sequence: \"!{0} press <chars>\" The characters must be on the module and the length must be exactly 20 characters long!";
	private bool startChallenge = false;
#pragma warning restore 414

	IEnumerator TwitchHandleForcedSolve()
	{
		yield return null;
		if (!string.IsNullOrEmpty(inputString))
			playBtns[rnd.Range(0, 4)].OnInteract();
		yield return null;
		foreach (char answerPart in answerString)
		{
			int idx = symbols.IndexOf(answerPart);
			symbolBtns[idx].OnInteract();
			yield return null;
		}
		yield return true;
	}

	IEnumerator TransformModule()
	{
		interactable = false;
		yield return null;
		for (int x = 0; x <= 60; x++)
		{
			lightTransform.intensity = x;
			yield return new WaitForSeconds(0);
		}
		Start();
		interactable = true;
		for (int x = 60; x >= 0; x--)
		{
			lightTransform.intensity = x;
			yield return new WaitForSeconds(0);
		}
	}

	IEnumerator DelayChallenge()
	{
		yield return new WaitForSeconds(5);
		startChallenge = false;
	}
	private IEnumerator challengeHandler;

	IEnumerator ProcessTwitchCommand(string command)
    {
		command = command.ToLower();
		if (!interactable)
		{
			yield return "sendochaterror This module is not interactable at the moment. Wait for a bit until the module is interactable again.";
			yield break;
		}

		if (command.RegexMatch(@"^challengeme$"))
		{
			if (challengeHandler == null)
				challengeHandler = DelayChallenge();
			if (!hardModeEnabled)
			{
				if (!canEnterHardMode)
				{
					yield return "sendtochaterror Someone already tampered with Module Listening. Hard mode cannot be enabled in this state.";
					yield break;
				}
				else if (!startChallenge)
				{
					if (!canTPEnterHardMode)
                    {
						yield return "sendtochat Module Listening (#{1}) refuses to enter hard mode in this state.";
						yield break;
					}

					startChallenge = true;
					yield return "sendtochat {0}? Are you sure you want to enable hard mode on Module Listening? Type in the same command within 5 seconds to confirm.";
					StartCoroutine(challengeHandler);
				}
				else
				{
					StopCoroutine(challengeHandler);
					hardModeEnabled = true;
					startChallenge = false;
					Debug.LogFormat("[Module Listening #{0}]: Hard mode enabled viva TP command! Restarting entire procedure...",moduleId);
					StartCoroutine(TransformModule());
					yield return "sendtochat You have asked for this.";
				}
			}
			else
				yield return "sendtochaterror Hard mode is already enabled. Can't turn back now, can you?";
			yield break;
		}
		else if (command.RegexMatch(@"^imscared"))
		{
			if (challengeHandler == null)
				challengeHandler = DelayChallenge();
			if (hardModeEnabled)
			{
				if (canEnterHardMode)
                {
					yield return "sendtochaterror Module Listening hard mode cannot be disabled without tampering with the play buttons first.";
					yield break;
				}
				if (!startChallenge)
				{
					startChallenge = true;
					yield return "sendtochat {0}? Are you sure you want to disable hard mode on Module Listening? Type in the same command within 5 seconds to confirm.";
					StartCoroutine(challengeHandler);
				}
				else
				{
					StopCoroutine(challengeHandler);
					hardModeEnabled = false;
					startChallenge = false;
					Debug.LogFormat("[Module Listening #{0}]: Hard mode disabled viva TP command! Restarting entire procedure...", moduleId);
					StartCoroutine(TransformModule());
					yield return "sendtochat You'll be fine now.";
				}
			}
			else
				yield return "sendtochaterror Hard mode is already disabled.";
			yield break;
		}
		else if(command.RegexMatch(@"^play all$"))
        {
            yield return null;
            playBtns[0].OnInteract();
            while (sound.isPlaying) yield return "trycancel";
			yield return new WaitForSeconds(0.5f);
            playBtns[1].OnInteract();
            while (sound.isPlaying) yield return "trycancel";
			yield return new WaitForSeconds(0.5f);
			playBtns[2].OnInteract();
            while (sound.isPlaying) yield return "trycancel";
			yield return new WaitForSeconds(0.5f);
			playBtns[3].OnInteract();
            yield break;
        }
		else if (command.RegexMatch(@"^play blue$"))
        {
            yield return null;
                playBtns[btnColors.ToList().IndexOf(2)].OnInteract();
            yield break;
        }
		else if (command.RegexMatch(@"^play red$"))
        {
            yield return null;
				playBtns[btnColors.ToList().IndexOf(0)].OnInteract();
			yield break;
        }
		else if (command.RegexMatch(@"^play green$"))
        {
            yield return null;
				playBtns[btnColors.ToList().IndexOf(1)].OnInteract();
			yield break;
        }
		else if (command.RegexMatch(@"^play yellow$"))
        {
            yield return null;
				playBtns[btnColors.ToList().IndexOf(3)].OnInteract();
			yield break;
        }
        if (command.StartsWith("press "))
        {
			string[] sub = command.Substring(6).Split();
			List<int> buttonPresses = new List<int>();
			string symbols = "!@%^(_|\\\'<";
			

			foreach (string part in sub)
			{
				for (int x = 0; x < part.Length; x++)
				{
					if (symbols.Contains(part[x]))
					{
						buttonPresses.Add(symbols.IndexOf(part[x]));
					}
					else
					{
						yield return "sendtochaterror The given character \""+ part[x] +"\" does not match any of the symbol buttons!";
					}
				}
			}
			if (buttonPresses.Count != 20)
			{
				yield return string.Format("sendtochaterror You did not request exactly 20 characters for the module to answer! You provided instead {0} character(s) in your command.", buttonPresses.Count);
			}
			// PPA functionality, in case of anyone activating Hard Mode
			List<int> correctAnswerInterepted = new List<int>();
			foreach (char sym in answerString)
				correctAnswerInterepted.Add(symbols.IndexOf(sym));
			for (int x = 0; x < buttonPresses.Count; x++)
			{
				
				if (correctAnswerInterepted.SequenceEqual(buttonPresses) && hardModeEnabled && x == 19)
					yield return string.Format("awardpoints {0}", PPAValue);
				yield return null;
				symbolBtns[buttonPresses[x]].OnInteract();
				yield return new WaitForSeconds(0.1f);
			}
			yield break;
        }
    }
}
