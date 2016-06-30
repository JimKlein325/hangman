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

      // Get["/newgame"] = _ => {
      //   Game newGame = new Game();
      //   return View["guess.cshtml",newGame]
      // };
      //
      // Post["/guess"] = _ => {
      //
      // };
      // 
      //
      // }
    }
  }
}
