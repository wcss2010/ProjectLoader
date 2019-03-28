using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLoader.SQLiteDB.Entitys
{
    public class ProjectBudgetInfo
    {
        public decimal? ProjectRFA
        {
            get;
            set;
        }

        public decimal? ProjectRFA1
        {
            get;
            set;
        }

        public decimal? ProjectRFA1_1
        {
            get;
            set;
        }

        public decimal? ProjectRFA1_1_1
        {
            get;
            set;
        }

        public decimal? ProjectRFA1_1_2
        {
            get;
            set;
        }

        public decimal? ProjectRFA1_1_3
        {
            get;
            set;
        }

        public decimal? ProjectRFA1_2
        {
            get;
            set;
        }

        public decimal? ProjectRFA1_3
        {
            get;
            set;
        }

        public decimal? ProjectRFA1_4
        {
            get;
            set;
        }

        public decimal? ProjectRFA1_5
        {
            get;
            set;
        }

        public decimal? ProjectRFA1_6
        {
            get;
            set;
        }

        public decimal? ProjectRFA1_7
        {
            get;
            set;
        }

        public decimal? ProjectRFA1_8
        {
            get;
            set;
        }

        public decimal? ProjectRFA1_9
        {
            get;
            set;
        }

        public decimal? ProjectRFA2
        {
            get;
            set;
        }

        public decimal? ProjectRFA2_1
        {
            get;
            set;
        }

        public decimal? Projectoutlay1
        {
            get;
            set;
        }

        public decimal? Projectoutlay2
        {
            get;
            set;
        }

        public decimal? Projectoutlay3
        {
            get;
            set;
        }

        public decimal? Projectoutlay4
        {
            get;
            set;
        }

        public decimal? Projectoutlay5
        {
            get;
            set;
        }

        public string ProjectRFArm
        {
            get;
            set;
        }

        public string ProjectRFA1rm
        {
            get;
            set;
        }

        public string ProjectRFA1_1rm
        {
            get;
            set;
        }

        public string ProjectRFA1_1_1rm
        {
            get;
            set;
        }

        public string ProjectRFA1_1_2rm
        {
            get;
            set;
        }

        public string ProjectRFA1_1_3rm
        {
            get;
            set;
        }

        public string ProjectRFA1_2rm
        {
            get;
            set;
        }

        public string ProjectRFA1_3rm
        {
            get;
            set;
        }

        public string ProjectRFA1_4rm
        {
            get;
            set;
        }

        public string ProjectRFA1_5rm
        {
            get;
            set;
        }

        public string ProjectRFA1_6rm
        {
            get;
            set;
        }

        public string ProjectRFA1_7rm
        {
            get;
            set;
        }

        public string ProjectRFA1_8rm
        {
            get;
            set;
        }

        public string ProjectRFA1_9rm
        {
            get;
            set;
        }

        public string ProjectRFA2rm
        {
            get;
            set;
        }

        public string ProjectRFA2_1rm
        {
            get;
            set;
        }

        public decimal ProjectRFA1zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA1_1zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA1_1_1zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA1_1_2zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA1_1_3zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA1_2zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA1_3zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA1_4zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA1_5zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA1_6zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA1_7zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA1_8zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA1_9zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA2zb
        {
            get;
            private set;
        }

        public decimal ProjectRFA2_1zb
        {
            get;
            private set;
        }

        public decimal ProjectZiChouJingFei { get; set; }

        public void Calc()
        {
            decimal d = 0m;
            d += ((!this.ProjectRFA1_1_1.HasValue) ? 0m : this.ProjectRFA1_1_1.Value);
            d += ((!this.ProjectRFA1_1_2.HasValue) ? 0m : this.ProjectRFA1_1_2.Value);
            d += ((!this.ProjectRFA1_1_3.HasValue) ? 0m : this.ProjectRFA1_1_3.Value);
            d += ((!this.ProjectRFA1_2.HasValue) ? 0m : this.ProjectRFA1_2.Value);
            d += ((!this.ProjectRFA1_3.HasValue) ? 0m : this.ProjectRFA1_3.Value);
            d += ((!this.ProjectRFA1_4.HasValue) ? 0m : this.ProjectRFA1_4.Value);
            d += ((!this.ProjectRFA1_5.HasValue) ? 0m : this.ProjectRFA1_5.Value);
            d += ((!this.ProjectRFA1_6.HasValue) ? 0m : this.ProjectRFA1_6.Value);
            d += ((!this.ProjectRFA1_7.HasValue) ? 0m : this.ProjectRFA1_7.Value);
            d += ((!this.ProjectRFA1_8.HasValue) ? 0m : this.ProjectRFA1_8.Value);
            d += ((!this.ProjectRFA1_9.HasValue) ? 0m : this.ProjectRFA1_9.Value);
            d += ((!this.ProjectRFA2_1.HasValue) ? 0m : this.ProjectRFA2_1.Value);
            this.ProjectRFA1_1 = new decimal?(((!this.ProjectRFA1_1_1.HasValue) ? 0m : this.ProjectRFA1_1_1.Value) + ((!this.ProjectRFA1_1_2.HasValue) ? 0m : this.ProjectRFA1_1_2.Value) + ((!this.ProjectRFA1_1_3.HasValue) ? 0m : this.ProjectRFA1_1_3.Value));
            this.ProjectRFA1 = this.ProjectRFA1_1 + ((!this.ProjectRFA1_2.HasValue) ? 0m : this.ProjectRFA1_2.Value) + ((!this.ProjectRFA1_3.HasValue) ? 0m : this.ProjectRFA1_3.Value) + ((!this.ProjectRFA1_4.HasValue) ? 0m : this.ProjectRFA1_4.Value) + ((!this.ProjectRFA1_5.HasValue) ? 0m : this.ProjectRFA1_5.Value) + ((!this.ProjectRFA1_6.HasValue) ? 0m : this.ProjectRFA1_6.Value) + ((!this.ProjectRFA1_7.HasValue) ? 0m : this.ProjectRFA1_7.Value) + ((!this.ProjectRFA1_8.HasValue) ? 0m : this.ProjectRFA1_8.Value) + ((!this.ProjectRFA1_9.HasValue) ? 0m : this.ProjectRFA1_9.Value);
            this.ProjectRFA2 = new decimal?((!this.ProjectRFA2_1.HasValue) ? 0m : this.ProjectRFA2_1.Value);
            this.ProjectRFA = this.ProjectRFA1 + this.ProjectRFA2;
            if (this.ProjectRFA.HasValue && this.ProjectRFA != 0m)
            {
                this.ProjectRFA1zb = Math.Round(this.ProjectRFA1.Value * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA2zb = Math.Round(this.ProjectRFA2.Value * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA1_1zb = Math.Round(this.ProjectRFA1_1.Value * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA1_1_1zb = Math.Round(((!this.ProjectRFA1_1_1.HasValue) ? 0m : this.ProjectRFA1_1_1.Value) * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA1_1_2zb = Math.Round(((!this.ProjectRFA1_1_2.HasValue) ? 0m : this.ProjectRFA1_1_2.Value) * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA1_1_3zb = Math.Round(((!this.ProjectRFA1_1_3.HasValue) ? 0m : this.ProjectRFA1_1_3.Value) * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA1_2zb = Math.Round(((!this.ProjectRFA1_2.HasValue) ? 0m : this.ProjectRFA1_2.Value) * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA1_3zb = Math.Round(((!this.ProjectRFA1_3.HasValue) ? 0m : this.ProjectRFA1_3.Value) * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA1_4zb = Math.Round(((!this.ProjectRFA1_4.HasValue) ? 0m : this.ProjectRFA1_4.Value) * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA1_5zb = Math.Round(((!this.ProjectRFA1_5.HasValue) ? 0m : this.ProjectRFA1_5.Value) * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA1_6zb = Math.Round(((!this.ProjectRFA1_6.HasValue) ? 0m : this.ProjectRFA1_6.Value) * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA1_7zb = Math.Round(((!this.ProjectRFA1_7.HasValue) ? 0m : this.ProjectRFA1_7.Value) * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA1_8zb = Math.Round(((!this.ProjectRFA1_8.HasValue) ? 0m : this.ProjectRFA1_8.Value) * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA1_9zb = Math.Round(((!this.ProjectRFA1_9.HasValue) ? 0m : this.ProjectRFA1_9.Value) * 100m / this.ProjectRFA.Value, 2);
                this.ProjectRFA2_1zb = Math.Round(((!this.ProjectRFA2_1.HasValue) ? 0m : this.ProjectRFA2_1.Value) * 100m / this.ProjectRFA.Value, 2);
                return;
            }
            this.ProjectRFA1zb = 0m;
            this.ProjectRFA2zb = 0m;
            this.ProjectRFA1_1zb = 0m;
            this.ProjectRFA1_1_1zb = 0m;
            this.ProjectRFA1_1_2zb = 0m;
            this.ProjectRFA1_1_3zb = 0m;
            this.ProjectRFA1_2zb = 0m;
            this.ProjectRFA1_3zb = 0m;
            this.ProjectRFA1_4zb = 0m;
            this.ProjectRFA1_5zb = 0m;
            this.ProjectRFA1_6zb = 0m;
            this.ProjectRFA1_7zb = 0m;
            this.ProjectRFA1_8zb = 0m;
            this.ProjectRFA1_9zb = 0m;
            this.ProjectRFA2_1zb = 0m;
        }
    }
}