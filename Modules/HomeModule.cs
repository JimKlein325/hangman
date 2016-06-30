using Nancy;
using System.Collections.Generic;
using Hangman.Objects;

namespace Hangman
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["welcome.cshtml"];

      Post["/new_game"] = _ => {
        Game newGame = new Game();
        return View["hangman.cshtml",newGame];
      };

      Post["/guess"] = _ => {
        string key = Request.Form["game"];
        Game game = Game.GetGameAtKey(key);
        return View["/new_guess", game];
      };

      Post["/attempt_guess"] = _ => {
        char guess = Request.Form["guess"];
        string key = Request.Form["game"];
        Game game = Game.GetGameAtKey(key);
        game.Guess(guess);
        if (game.State == GameState.IllegalGuess) return View["/new_guess",game];
        return View["hangman.cshtml",game];
      };
    }
  }
}
