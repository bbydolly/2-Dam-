using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamenOmeletteCris
{
    

    internal class OmeletteAutomator
    {
        private int NOnions = 0;
        private int NPotatoes = 0;
        private int NOmelettes=0;
        public bool cooking = true;
        private readonly object l=new object();

        private void Omelette() 
        { 
            while(cooking)
            {
                lock(l) 
                {
                    if(NOnions<5 && NPotatoes<5)
                    {
                        Console.WriteLine("Waiting...");
                        Monitor.Wait(l);
                    }
                    NOnions -= 5;
                    NPotatoes -= 5;
                    NOmelettes++;
                    Console.WriteLine($"Onions:{NOnions,3}"+
                        $"Patatoes:{NPotatoes,3}"+
                        $"Omelettes: {NOmelettes,3}");
                    if(NOmelettes==10)
                    {
                        cooking = false;
                    }
                }

            }

        }
        private void Ingredient(string name, ref int ingredient)
        {
            while (cooking)
            {
                lock (l)
                {
                    if(cooking)
                    {
                        ingredient++;
                        Console.WriteLine($"{name,7}:{ingredient,3}");
                        if(NOnions>=5 && NPotatoes>=5)
                        {
                            Monitor.Pulse(l); //ya pulso crear omelettes
                            //ya hay ingredientes necesarios¡¡
                            //Omelette() estaba esperando por los ingredientes
                        }
                    }

                }

            }

        }
        
        public void Init()
        {
            Thread tOnion = new Thread(()=>Ingredient("Onion",ref NOnions));
            Thread tPotato = new Thread(() => Ingredient("Potato", ref NPotatoes));
            Thread tOmelette = new Thread(() => Omelette());
            tOnion.Start();
            tPotato.Start();
            tOmelette.Start();
            tOmelette.Join();

        }
    }
}


