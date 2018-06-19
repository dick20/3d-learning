using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PristsAndDevilsState{
    public int leftPriests;
    public int rightPriests;
    public int leftDevils;
    public int rightDevils;
    public bool boat_pos;       //true表示船在左边，false表示船在右边
    public PristsAndDevilsState parent_state;
    //缺省构造函数
    public PristsAndDevilsState() { }
    //带参构造函数
    public PristsAndDevilsState(int leftPriests, int leftDevils, int rightPriests,
      int rightDevils, bool boat_pos, PristsAndDevilsState parent_state)
    {
        this.leftPriests = leftPriests;
        this.rightPriests = rightPriests;
        this.leftDevils = leftDevils;
        this.rightDevils = rightDevils;
        this.boat_pos = boat_pos;
        this.parent_state = parent_state;
    }
    //复制构造函数
    public PristsAndDevilsState(PristsAndDevilsState temp)
    {
        this.leftPriests = temp.leftPriests;
        this.rightPriests = temp.rightPriests;
        this.leftDevils = temp.leftDevils;
        this.rightDevils = temp.rightDevils;
        this.boat_pos = temp.boat_pos;
        this.parent_state = temp.parent_state;
    }
    //重载运算符==
    public static bool operator ==(PristsAndDevilsState lhs, PristsAndDevilsState rhs) {
        return (lhs.leftPriests == rhs.leftPriests && lhs.rightPriests == rhs.rightPriests  &&
        lhs.leftDevils == rhs.leftDevils && lhs.rightDevils == rhs.rightDevils &&
        lhs.boat_pos == rhs.boat_pos);
    }
    //重载运算符！=
    public static bool operator !=(PristsAndDevilsState lhs, PristsAndDevilsState rhs) {
        return !(lhs == rhs);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        if (obj.GetType().Equals(this.GetType()) == false)
        {
            return false;
        }
        PristsAndDevilsState temp = (PristsAndDevilsState)obj;
        return this.leftPriests.Equals(temp.leftPriests) && this.rightPriests.Equals(temp.rightPriests) && this.rightDevils.Equals(temp.rightDevils) 
            && this.leftDevils.Equals(temp.leftDevils) && this.boat_pos.Equals(temp.boat_pos);
    }

   public override int GetHashCode()
    {
        return this.leftPriests.GetHashCode() + this.rightPriests.GetHashCode() +this.leftDevils.GetHashCode() 
           + this.rightDevils.GetHashCode() + this.boat_pos.GetHashCode();
    }
    //判断当前状态是否正确
    public bool isValid()
    {
        return ((leftPriests == 0 || leftPriests >= leftDevils) && (rightPriests == 0 || rightPriests >= rightDevils));
    }

    public static PristsAndDevilsState BFS(PristsAndDevilsState start, PristsAndDevilsState end)
    {
        //存放到达目的的路径状态
        Queue<PristsAndDevilsState> found = new Queue<PristsAndDevilsState>();
        PristsAndDevilsState temp = new PristsAndDevilsState(start.leftPriests, start.leftDevils, start.rightPriests, start.rightDevils, start.boat_pos, null);
        //当前状态入队
        found.Enqueue(temp);
        //队列元素数目大于0
        while (found.Count > 0)
        {
            temp = found.Peek();
            //当状态等于末状态时，可以终止继续寻找，只需通过parent_state来找出开始状态的下一个状态即可
            //当然也可以把整个路径显示出来
            if (temp == end)
            {
                while (temp.parent_state != start)
                {
                    temp = temp.parent_state;
                }
                return temp;
            }
            found.Dequeue();

            // 判断该状态的船的位置，船若在左边
            if (temp.boat_pos)
            {
                // 将一个牧师移动到右边
                if (temp.leftPriests > 0)
                {
                    PristsAndDevilsState next = new PristsAndDevilsState(temp);
                    next.parent_state = new PristsAndDevilsState(temp);
                    next.boat_pos = false;
                    next.leftPriests--;
                    next.rightPriests++;
                    if (next.isValid() && !found.Contains(next))
                    {
                        found.Enqueue(next);
                    }
                }
                // 将一个恶魔移动到右边
                if (temp.leftDevils > 0)
                {
                    PristsAndDevilsState next = new PristsAndDevilsState(temp);
                    next.parent_state = new PristsAndDevilsState(temp);
                    next.boat_pos = false;
                    next.leftDevils--;
                    next.rightDevils++;
                    if (next.isValid() && !found.Contains(next))
                    {
                        found.Enqueue(next);
                    }
                }
                // 将一个牧师以及一个恶魔移动到右边
                if (temp.leftDevils > 0 && temp.leftPriests > 0)
                {
                    PristsAndDevilsState next = new PristsAndDevilsState(temp);
                    next.parent_state = new PristsAndDevilsState(temp);
                    next.boat_pos = false;
                    next.leftDevils--;
                    next.rightDevils++;
                    next.leftPriests--;
                    next.rightPriests++;
                    if (next.isValid() && !found.Contains(next))
                    {
                        found.Enqueue(next);
                    }
                }
                // 将两个牧师移动到右边
                if (temp.leftPriests > 1)
                {
                    PristsAndDevilsState next = new PristsAndDevilsState(temp);
                    next.parent_state = new PristsAndDevilsState(temp);
                    next.boat_pos = false;
                    next.leftPriests -= 2;
                    next.rightPriests += 2;
                    if (next.isValid() && !found.Contains(next))
                    {
                        found.Enqueue(next);
                    }
                }
                // 将两个恶魔移动到右边
                if (temp.leftDevils > 1)
                {
                    PristsAndDevilsState next = new PristsAndDevilsState(temp);
                    next.parent_state = new PristsAndDevilsState(temp);
                    next.boat_pos = false;
                    next.leftDevils -= 2;
                    next.rightDevils += 2;
                    if (next.isValid() && !found.Contains(next))
                    {
                        found.Enqueue(next);
                    }
                }
            }
            // 判断该状态的船的位置，船若在右边
            else
            {
                // 将一个牧师移动到左边
                if (temp.rightPriests > 0)
                {
                    PristsAndDevilsState next = new PristsAndDevilsState(temp);
                    next.parent_state = new PristsAndDevilsState(temp);
                    next.boat_pos = true;
                    next.rightPriests--;
                    next.leftPriests++;
                    if (next.isValid() && !found.Contains(next))
                    {
                        found.Enqueue(next);
                    }
                }
                // 将一个恶魔移动到右边
                if (temp.rightDevils > 0)
                {
                    PristsAndDevilsState next = new PristsAndDevilsState(temp);
                    next.parent_state = new PristsAndDevilsState(temp);
                    next.boat_pos = true;
                    next.rightDevils--;
                    next.leftDevils++;
                    if (next.isValid() && !found.Contains(next))
                    {
                        found.Enqueue(next);
                    }
                }
                // 将一个牧师一个恶魔移动到右边
                if (temp.rightDevils > 0 && temp.rightPriests > 0)
                {
                    PristsAndDevilsState next = new PristsAndDevilsState(temp);
                    next.parent_state = new PristsAndDevilsState(temp);
                    next.boat_pos = true;
                    next.rightDevils--;
                    next.leftDevils++;
                    next.rightPriests--;
                    next.leftPriests++;
                    if (next.isValid() && !found.Contains(next))
                    {
                        found.Enqueue(next);
                    }
                }
                // 将两个恶魔移动到右边
                if (temp.rightDevils > 1)
                {
                    PristsAndDevilsState next = new PristsAndDevilsState(temp);
                    next.parent_state = new PristsAndDevilsState(temp);
                    next.boat_pos = true;
                    next.rightDevils -= 2;
                    next.leftDevils += 2;
                    if (next.isValid() && !found.Contains(next))
                    {
                        found.Enqueue(next);
                    }
                }
                // 将两个牧师移动到右边
                if (temp.rightPriests > 1)
                {
                    PristsAndDevilsState next = new PristsAndDevilsState(temp);
                    next.parent_state = new PristsAndDevilsState(temp);
                    next.boat_pos = true;
                    next.rightPriests -= 2;
                    next.leftPriests += 2;
                    if (next.isValid() && !found.Contains(next))
                    {
                        found.Enqueue(next);
                    }
                }
            }
        }
        return null;
    }
}