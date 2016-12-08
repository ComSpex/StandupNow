using System;
using System.Threading;

public class Example {
	public static void Main() {
		Example ex = new Example();
		ex.StartTimer(3000);

		Console.WriteLine("Press Enter to end the program.");
		Console.ReadLine();
	}

	public void StartTimer(int dueTime) {
		Timer t = new Timer(new TimerCallback((state)=> {
			Timer to = (Timer)state;
			DateTime now = DateTime.Now;
			if(TimeHasCome(now)) {
				Console.WriteLine("{0:O} : MessageBeep will be called.",now);
			} else {
				Console.WriteLine("{0:O} : The timer callback executes.",now);
			}
		}));
		t.Change(dueTime,dueTime);
	}
	private bool TimeHasCome(DateTime now) {
		TimeSpan span = new TimeSpan(now.Ticks);
		return span.Minutes%30==0;
	}
}