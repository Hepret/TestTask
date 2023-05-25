using System.Collections.Generic;
using TestTasks;

namespace TestTask.Implementation
{
    public class Test5 : ITest5
    {
        /// <summary>
        /// Возвращает "все человечество", рожденное, начиная с переданного в качестве аргумента предка (включительно)
        /// </summary>
        /// <param name="oldestHuman"></param>
        /// <returns>"все человечество"</returns>
        public IEnumerable<HumanWithParent> EnumAllHuman(HumanWithChildren oldestHuman)
        {
            var humans = new List<HumanWithParent>();
            EnumAllHumanRec(oldestHuman, null);
            
            void EnumAllHumanRec(HumanWithChildren human, HumanWithChildren parent)
            {
                var humanWithParent = new HumanWithParent()
                {
                    Parent = parent,
                    Name = human.Name
                };
                humans.Add(humanWithParent);

                if (human.Children == null || human.Children.Length == 0) return;
                
                foreach (var child in human.Children)
                {
                    EnumAllHumanRec(child, parent);
                }
            }

            return humans;
        }
        
        

        public IEnumerable<HumanWithParent> EnumAllHuman(IEnumerable<HumanWithChildren> oldestHumanGroup)
        {
            throw new System.NotImplementedException();
        }
    }
}