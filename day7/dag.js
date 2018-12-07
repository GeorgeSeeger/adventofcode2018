const fs = require('fs');
let input = fs.readFileSync("day7/input.txt", "utf-8").split("\n").map(l => [ l.substr(5, 1), l.substr(36, 1)]);
let nodes = {};

for (var i = 0; i < input.length; i++) {
    var pair = input[i];
    var left = pair[0];
    if (!nodes[left]) {nodes[left] = []}
    nodes[left].push(pair[1]);
    nodes[left].sort();
}

var sorted = [];
var starts = [];
Object.keys(nodes).forEach(n => {
    if (Object.values(nodes).every(a => !a.includes(n))) {
        starts.push(n);
    }
})
starts.sort();

while (starts.length > 0) {
    var start = starts.pop();
    sorted.push(start);
    var startNodes = nodes[start]
    for (var i = 0; i < startNodes.length; i++) {
        var node = nodes[start]
        nodes[start] = nodes[start].filter(n => n !== node);
        if (!Object.values(nodes).some(a => a.includes(node))) {
            sorted.push(node);
        } //nodes[start].push(node);
    }
}

console.log(sorted.join(""));