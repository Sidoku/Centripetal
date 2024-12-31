<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

This 2D platformer is heavily inspired by Celeste , SpeedRunners: the Game, and 2D Sonic the Hedgehog. The player will spend most of the time “sight-reading” levels as obstacles appear in their way. Moving quickly and smoothly is the core experience. The game story follows a Yo-Yo's journey after it had been left behind accidentally by the child that owns it. The child has left for school and the Yo-Yo must navigate the world in the fastest possible time to return to its favourite human as a Yo-Yo always does.

## Game Mechanics

The grapple is the primary mechanic and everything else is built and implemented to support that mechanic. Mechanics are listed below in order of complexity:

* Move roll: Players generate velocity slowly, like a car, and moving in the other direction means you must first overcome the initial velocity. There is no max speed, and it continuously adds speed to the player, even while in the air. This should feel slow at first, but level design indicates we start each level with some velocity through gravity (start the player higher than the ground). Slowing down is a punishment for the player.
* Jump/Double Jump: Players can jump once on the ground and jump again while in air. It resets upon touching the ground. Jumping in air resets downward velocity to zero before adding the upwards jump velocity.
* Dash: The dash starts with Celeste’s dash as an example, except it only adds a fixed amount of speed in the direction the player indicates. The dash resets upon touching the ground. Can be used by player to gain a burst of speed after stopping/slowing down Enables quickly changing direction in the air Utilized to maximize the acceleration of the player (spamming it whenever it is available)
* Grapple: Players can grapple to specific yellow points on the map when they are within the radius ( 4 units ). When within that radius, an animation plays with a button prompt for the player to grapple to it. Players accelerate when grappling. Grapple has no recharge or reset – provided you are in range, you may grapple.


### Built With

* Unity Engine

### Prerequisites

* Windows 10+
* Unity Editor


### Installation

1. Clone the repo
2. Open Project in Unity Editor
3. Play the Project inside Unity Editor or Make a Build
4. Enjoy!

<!-- CONTACT -->
## Contact

* Siddharth Singhai - sidsinghai97@gmail.com
* [![LinkedIn][linkedin-shield]][linkedin-url]
* [![Portfolio][portfolioIcon-url]][portfolio-url]

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[portfolioIcon-url]: https://img.shields.io/badge/-Portfolio-brightgreen
[linkedin-url]: https://www.linkedin.com/in/siddharthsinghai97/
[portfolio-url]: https://sidsinghai97.wixsite.com/portfolio
