using System;

namespace WarlordsCS
{
    interface IController
    {
        bool TimeIsOver();

        void ControlNextLane(int playerIndex);

        void ControlPrevLane(int playerIndex);
    }
}
