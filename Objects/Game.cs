using System;
using System.Collections.Generic;

namespace Hangman.Objects
{

  public enum GameState
  {
    Initial,
    GameLost,
    GameWon,
    IllegalGuess,
    CorrectGuess,
    IncorrectGuess
  }

  public class Game
  {
    private static string[] _potentialGuesses = new string[] {"welcome", "friday", "random", "words"};
    private string _wordToGuess;
    private int _incorrectGuessesLeft;
    private char[] _correctGuesses;
    private List<char> _incorrectGuesses;
    private List<char> _allGuesses;
    public GameState State {get; set;}
    private static Dictionary<string, Game> _allGames = new Dictionary<string, Game> {};

    public Game() {
      if (_allGames.Count == _potentialGuesses.Length) _allGames.Clear();
      State = GameState.Initial;
      _wordToGuess = Game.GenerateRandomWord();
      _incorrectGuessesLeft = 6;
      _correctGuesses = new char[_wordToGuess.Length];
      _incorrectGuesses = new List<char> {};
      _allGuesses = new List<char> {};
      for (int i = 0 ; i < _wordToGuess.Length ; i++) {
        _correctGuesses[i] = '_';
      }
      _allGames.Add(_wordToGuess,this);
    }

    public static Game GetGameAtKey(string keyVal) {
      return (_allGames[keyVal]);
    }

    public static string GenerateRandomWord ()
    {
      Random rnd = new Random();
      int index = rnd.Next(_potentialGuesses.Length);
      string word = _potentialGuesses[index];
      if (_allGames.ContainsKey(word)) return Game.GenerateRandomWord();
      return word;
    }

    public string CorrectGuessesToString() {
      string returnString = "";
      foreach(char c in _correctGuesses) {
        returnString += (c + " ");
      }
      return returnString;
    }

    public string GetWordToGuess() {
      return _wordToGuess;
    }

    public string IncorrectGuessesToString() {
      string returnString = _incorrectGuesses[0].ToString();
      for (int i = 1 ; i < _incorrectGuesses.Count ; i++) {
        returnString += (", " + _incorrectGuesses[i]);
      }
      return returnString;
    }


    public bool IsCorrectGuess(char guess) {
      bool isCorrect = false;
      for (int i = 0 ; i < _wordToGuess.Length ; i++) {
        if (_wordToGuess[i]==guess) {
          isCorrect = true;
          _correctGuesses[i] = guess;
        }
      }
      return isCorrect;
    }

    private bool AlreadyGuessed(char guess) {
      foreach(char c in _allGuesses) {
        if (guess == c) return true;
      }
      return false;
    }

    private bool IsWordComplete() {
      string s = new string(_correctGuesses);
      if (s.Contains("_")) return false;
      return true;
    }

    public Game Guess(char guess) {
      if (AlreadyGuessed(guess)) {
        State = GameState.IllegalGuess;
        return this;
      }
      if (IsCorrectGuess(guess)) {
        State = GameState.CorrectGuess;
        if (IsWordComplete()) State = GameState.GameWon;
        return this;
      }
      State = GameState.IncorrectGuess;
      _incorrectGuessesLeft--;
      if (_incorrectGuessesLeft==0) State = GameState.GameLost;
      return this;
    }
  }
}
