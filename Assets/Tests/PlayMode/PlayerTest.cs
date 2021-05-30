using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTest
    {

        private bool sceneLoaded = false;

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PlayerWinsWith1HP()
        {
            // ARRANGE
            // Load the scene that will be tested.
            SceneManager.LoadScene("SampleScene");
            SceneManager.sceneLoaded += OnSceneLoaded;

            yield return new WaitWhile(() => sceneLoaded == false);
            yield return new WaitForFixedUpdate();
            yield return new WaitForSeconds(3);

            // ACT
            ReferenceManager.Player.MoveLeft();
            yield return new WaitForSeconds(5.6f);
            ReferenceManager.Player.MoveRight();
            yield return new WaitForSeconds(0.4f);
            ReferenceManager.Player.MoveJump();
            yield return new WaitForSeconds(3);
            ReferenceManager.Player.MoveLeft();
            yield return new WaitForSeconds(3f);
            ReferenceManager.Player.MoveRight();
            yield return new WaitForSeconds(1.5f);
            ReferenceManager.Player.MoveJump();
            yield return new WaitForSeconds(1.7f);
            ReferenceManager.Player.MoveLeft();
            yield return new WaitForSeconds(6);


            // ASSERT
            Assert.True(ReferenceManager.Player.Health == 1);
        }

        [UnityTest]
        public IEnumerator PlayerWinsWithAllCoinsPickedUp()
        {
            // ARRANGE
            // Load the scene that will be tested.
            SceneManager.LoadScene("SampleScene");
            SceneManager.sceneLoaded += OnSceneLoaded;

            yield return new WaitWhile(() => sceneLoaded == false);
            yield return new WaitForFixedUpdate();
            yield return new WaitForSeconds(3);

            // ACT
            ReferenceManager.Player.MoveLeft();
            yield return new WaitForSeconds(4.6f);
            ReferenceManager.Player.MoveRight();
            yield return new WaitForSeconds(0.1f);
            ReferenceManager.Player.MoveRight();
            yield return new WaitForSeconds(2f);
            ReferenceManager.Player.MoveLeft();
            yield return new WaitForSeconds(1.8f);
            ReferenceManager.Player.MoveLeft();
            yield return new WaitForSeconds(2.45f);
            ReferenceManager.Player.MoveRight();
            yield return new WaitForSeconds(0.3f);
            ReferenceManager.Player.MoveRight();
            yield return new WaitForSeconds(2.5f);
            ReferenceManager.Player.MoveLeft();
            yield return new WaitForSeconds(0.6f);
            ReferenceManager.Player.MoveJump();
            yield return new WaitForSeconds(1.5f);
            ReferenceManager.Player.MoveLeft();
            yield return new WaitForSeconds(4.5f);

            // ASSERT
            Assert.True(ReferenceManager.Player.Coins == 100);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            sceneLoaded = true;
        }
    }
}
