using Nancy;
using System.Collections.Generic;
using CDOrganizer.Objects;

namespace Hangman
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] View["index.cshtml"];

      
    }
  }
}
