using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Threading;

public class TestSuite
{
    private Game game;

    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(game.gameObject);
    }


    [UnityTest]
    public IEnumerator AsteroidsMoveDown()
    {
        GameObject gameGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();
        
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        
        float initialYPos = asteroid.transform.position.y;
        
        yield return new WaitForSeconds(0.1f);
        
        Assert.Less(asteroid.transform.position.y, initialYPos);
      
        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator GameOverOccursOnAsteroidCollision()
    {
        GameObject gameGameObject =
           MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        Game game = gameGameObject.GetComponent<Game>();
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        //1
        asteroid.transform.position = game.GetShip().transform.position;
        //2
        yield return new WaitForSeconds(0.1f);

        //3
        Assert.True(game.isGameOver);

        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator NewGameRestartsGame()
    {
        //1
        game.isGameOver = true;
        game.NewGame();
        //2
        Assert.False(game.isGameOver);
        yield return null;
    }


    [UnityTest]
    public IEnumerator LaserMovesUp()
    {
        // 1
        GameObject laser = game.GetShip().SpawnLaser();
        // 2
        float initialYPos = laser.transform.position.y;
        yield return new WaitForSeconds(0.1f);
        // 3
        Assert.Greater(laser.transform.position.y, initialYPos);
    }

    [UnityTest]
    public IEnumerator LaserDestroysAsteroid()
    {
        // 1
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject laser = game.GetShip().SpawnLaser();
        laser.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        // 2
        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }

    [UnityTest]
    public IEnumerator DestroyedAsteroidRaisesScore()
    {
        // 1
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject laser = game.GetShip().SpawnLaser();
        laser.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        // 2
        Assert.AreEqual(game.score, 1);
    }

    [UnityTest]
    public IEnumerator RestartResetsScore()
    {
        game.NewGame();

        Assert.AreEqual(game.score, 0);

        yield return null;
    }

    [UnityTest]
    public IEnumerator AsteroidOneGameOver()
    {
          // Collision

        GameObject gameGameObject =
           MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        Game game = gameGameObject.GetComponent<Game>();
    
        GameObject asteroid =
         MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Asteroid"));
      
        //1
        asteroid.transform.position = game.GetShip().transform.position;
        //2
        yield return new WaitForSeconds(0.1f);

        //3
        Assert.True(game.isGameOver); 
    }


    [UnityTest]
    public IEnumerator AsteroidTwoGameOver()
    {
        // Collision

        GameObject gameGameObject =
           MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        Game game = gameGameObject.GetComponent<Game>();

        GameObject asteroid =
         MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Asteroid2"));

        //1
        asteroid.transform.position = game.GetShip().transform.position;
        //2
        yield return new WaitForSeconds(0.1f);

        //3
        Assert.True(game.isGameOver);
    }

    [UnityTest]
    public IEnumerator AsteroidThreeGameOver()
    {
        // Collision

        GameObject gameGameObject =
           MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        Game game = gameGameObject.GetComponent<Game>();

        GameObject asteroid =
         MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Asteroid3"));

        //1
        asteroid.transform.position = game.GetShip().transform.position;
        //2
        yield return new WaitForSeconds(0.1f);

        //3
        Assert.True(game.isGameOver);
    }

    [UnityTest]
    public IEnumerator AsteroidFourGameOver()
    {
        // Collision

        GameObject gameGameObject =
           MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        Game game = gameGameObject.GetComponent<Game>();

        GameObject asteroid =
         MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Asteroid4"));

        //1
        asteroid.transform.position = game.GetShip().transform.position;
        //2
        yield return new WaitForSeconds(0.1f);

        //3
        Assert.True(game.isGameOver);
    }
}

