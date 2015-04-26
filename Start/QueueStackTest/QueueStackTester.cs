using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AlgorithmLib.QueueStack;

namespace Start.QueueStackTest
{
    public class QueueStackTester : ITest
    {
        public void Test()
        {
            var aCards = new QueueT<int>();
            aCards.EnQueue(2); 
            aCards.EnQueue(4); 
            aCards.EnQueue(1); 
            aCards.EnQueue(2); 
            aCards.EnQueue(5); 
            aCards.EnQueue(6);

            var bCards = new QueueT<int>();
            bCards.EnQueue(3);
            bCards.EnQueue(1);
            bCards.EnQueue(3);
            bCards.EnQueue(5);
            bCards.EnQueue(6);
            bCards.EnQueue(4);

            var destop = new StackT<int>();

            //Game Start
            while (aCards.Count !=0 && bCards.Count != 0)
            {
                //a pay a card
                var aCard = aCards.DeQueue();
                Console.WriteLine(string.Format("A pay {0}", aCard));
                //a win
                if (aCards.Count == 0)
                {
                    Console.Write("A win!");
                    break;
                }
                    
                //push to destop
                destop.Push(aCard);
                Console.WriteLine(string.Format("Destop get {0}", aCard));
                //jude the destop
                JudegeDestop(aCard, destop, aCards);

                //a pay a card
                var bCard = bCards.DeQueue();
                Console.WriteLine(string.Format("B pay {0}", bCard));
                //a win
                if (bCards.Count == 0)
                {
                    Console.Write("B win!");
                    break;
                }
                    
                //push to destop
                destop.Push(bCard);
                Console.WriteLine(string.Format("Destop get {0}", bCard));
                //jude the destop
                JudegeDestop(bCard, destop, bCards);

            }

            if (aCards.Count == 0)
            {
                Console.WriteLine("A win");
            }
            else
            {
                Console.WriteLine("B win");
            }
        }

        private void JudegeDestop(int aCard, StackT<int> destop, QueueT<int> aCards)
        {
            int count = 0;
            foreach (var card in destop)
            {
                if (card == aCard)
                {
                    count++;
                }
            }

            var newCards = new List<int>();

            if (count == 2)
            {
                var newFirstCard = destop.Pop();
                newCards.Add(newFirstCard);

                int newCard = 0;
                while ((newCard = destop.Peek()) != newFirstCard)
                {
                    newCards.Add(destop.Pop());
                }
                newCard = destop.Pop();
                newCards.Add(newCard);

                foreach (var card in newCards)
                {
                    if(card == 0) continue;
                    aCards.EnQueue(card);
                    Console.Write(string.Format("Get {0} ", card));
                }
                Console.WriteLine();
            }
        }
    }
}
