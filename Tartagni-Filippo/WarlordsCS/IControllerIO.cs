using System.Collections.Generic;

namespace WarlordsCS
{
    interface IControllerIO
    {
        IList<string> ReadScore();
        void WriteNewScore(Score score);
        void ClearFile();
    }
}
