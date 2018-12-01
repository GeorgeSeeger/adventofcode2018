let fs = require('fs');
let input = fs.readFileSync("day1/input", 'utf-8').trim();
let data = input.split("\n");
let dumboParseInt = s => (s.includes("+") ? 1 : -1) * parseInt(s.slice(1))
let ints = data.map(dumboParseInt);
let answer = ints.reduce((acc, i) => acc + i, 0)

console.log(answer);

let frequencies = [0];
for (var i = 0; i < 1000000; i++) {
  let next = frequencies[frequencies.length - 1] + ints[i % ints.length];
  if (frequencies.includes(next)) {
    console.log(next);
    break;
  }
  frequencies.push(next);
}