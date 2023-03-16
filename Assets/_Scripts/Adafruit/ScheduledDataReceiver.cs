using System.Collections;
using UnityEngine;

namespace Adafruit
{
    public class ScheduledDataReceiver : DataReceiver
    {
        public float InvokeTimer = 1f;
        
        protected override void Start()
        {
            base.Start();
            AutoInvoke = false;
        }

        private IEnumerator PeriodicallyInvoke_CO()
        {
            while (true)
            {
                yield return new WaitForSeconds(InvokeTimer);
                
            }
        }
    }
}