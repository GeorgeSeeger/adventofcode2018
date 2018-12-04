let fs = require('fs');

class Guard {
  constructor(id) {
    this.id = id;
    this.sleepingMinutes = [];
  }

  beginShift(time) {
  }

  fallAsleep(minute) {
    this.fellAsleepAt = parseInt(minute);
  }

  wakeUp(minute) {
    var upAt = parseInt(minute);
    var asleepFor = new Array(upAt - this.fellAsleepAt)
                      .fill(0)
                      .map((o, i) => this.fellAsleepAt + i);
    this.sleepingMinutes = this.sleepingMinutes.concat(asleepFor);
  }

  get timeAsleep() {
    return this.sleepingMinutes.length;
  }

  get mostSleptMinute() {
    var a = this.sleepingMinutes.slice()
                                .sort((a, b) => 
          this.sleepingMinutes.filter(v => v === b).length
          - this.sleepingMinutes.filter(v => v === a).length);
    return a[0];
  }

  timesSleptAt(minute) {
    return this.sleepingMinutes.filter(m => m === minute).length;
  }
}

let input = fs.readFileSync("day4/input", "utf-8").split("\n");
input.sort();

var guards = {},
    id,
    guard;

for (var i = 0; i < input.length; i++) {
  let record = input[i];
  if (record.includes("#")) {
    id = /#(\d+)/.exec(record)[1];
    guard = guards[id] || (guards[id] = new Guard(id));
    guard.beginShift();
  }
  else if (record.includes("falls asleep")) {
    let time = /\d\d:(\d+)]/.exec(record)[1];
    guard.fallAsleep(time)
  }
  else if (record.includes("wakes up")) {
    let time = /\d\d:(\d+)]/.exec(record)[1];
    guard.wakeUp(time);
  }
}

//part 1
let sleepiestGuard = Object.values(guards).sort((a, b) => b.timeAsleep - a.timeAsleep)[0];
console.log(sleepiestGuard.id * sleepiestGuard.mostSleptMinute)

// part 2
let consistentestGuard = Object.values(guards).sort((a, b) => b.timesSleptAt(b.mostSleptMinute) - a.timesSleptAt(a.mostSleptMinute))[0];
console.log(consistentestGuard.id * consistentestGuard.mostSleptMinute);