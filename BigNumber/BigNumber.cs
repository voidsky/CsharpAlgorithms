﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;

namespace BigNumber
{
    public class BigNumber
    {
        public Algorithms.Queue<int> inQueue;

        public BigNumber(string strNumber)
        {
            inQueue = new Algorithms.Queue<int>();
            

            foreach (char chr in strNumber)
                if (int.TryParse(chr.ToString(), out int i))
                    inQueue.Enqueue(i);
        }

        public void DivBy(int x, out int reminder)
        {
            Algorithms.Queue<int> resultQueue;
            resultQueue = new Algorithms.Queue<int>();

            reminder = 0;
            if (inQueue.Size() <= 0) return;
            int i = 0;
            while (inQueue.Size() > 0)
            {
                if (i == 0)
                {
                    i = inQueue.Dequeue();
                }
                
                if (i < x && inQueue.Size()>0)
                {
                    i = i * 10 + inQueue.Dequeue();
                }
                int divResult = i / x;
                resultQueue.Enqueue(divResult);
                i = i - divResult * x;


            }
            reminder = i;
            if (resultQueue.Size() == 0) resultQueue.Enqueue(0);

            inQueue = new Algorithms.Queue<int>();
            foreach (var item in resultQueue)
            {
                inQueue.Enqueue(item);
            }
        }



        public void ToBinary()
        {
         
        }

    }
}
