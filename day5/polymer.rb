input = File.readlines("day5/input.txt")[0]

len = 1
def isSwitchCase(a, b) 
    a.ord + 32 == b.ord || a.ord == b.ord + 32
end

until (len == input.length) do
    len = input.length
    input = input.chars.map.with_index{|c, i|
        next_char = i + 1 < len ? input[i + 1] : c
        prev_char = i - 1 > 0 ? input[i - 1] : c
        isSwitchCase(next_char, c) ^ isSwitchCase(prev_char, c) ? "|" : c
    }.reject{|c| c == "|"}
    .join
end

puts input.length