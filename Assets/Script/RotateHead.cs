using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class RotateHead : MonoBehaviour
    {
        public GameObject head;
        public int zz;
        public char ch;
        public char oldCh;
        public bool first = true;
        // Start is called before the first frame update
        private void OnEnable() {
            oldCh = 'd';
            first = true;
            StartCoroutine(FindHead());
        }

        IEnumerator FindHead() {
            yield return new WaitForSeconds(0.1f);
            if (head == null) {
                head = GameObject.Find("Player");

            }
        }
        // Update is called once per frame
        void Update() {
            if (head == null)
                return;
            if (Input.GetButtonDown("Up")) {
                ch = 'w';
                zz = 0;
                Rotate(ch, zz);
            } else if (Input.GetButtonDown("Down")) {
                ch = 's';
                zz = 180;
                Rotate(ch, zz);
            } else if (Input.GetButtonDown("Left")) {
                ch = 'a';
                zz = 90;
                Rotate(ch, zz);
            } else if (Input.GetButtonDown("Right")) {
                ch = 'd';
                zz = -90;
                Rotate(ch, zz);
            }
        }

        void Rotate(char c, int z) {
            if (!first) {
                if (oldCh == 'd' && c != 'a') {
                    head.transform.eulerAngles = new Vector3(0, 0, z);
                    oldCh = c;
                } else if (oldCh == 'a' && c != 'd') {
                    head.transform.eulerAngles = new Vector3(0, 0, z);
                    oldCh = c;
                } else if (oldCh == 'w' && c != 's') {
                    head.transform.eulerAngles = new Vector3(0, 0, z);
                    oldCh = c;
                } else if (oldCh == 's' && c != 'w') {
                    head.transform.eulerAngles = new Vector3(0, 0, z);
                    oldCh = c;
                } else {
                    return;
                }
            } else{
                first = false;
            }

        }
    }
}
