input = File.readlines("day5/input.txt")[0].chomp()

def react_polymer(str)
    len = nil
    until (len == str.length) do
        len = str.length
        (0...len-1).each do |i|
            a, b = str[i], str[i+1]
            if (a.ord + 32 == b.ord || a.ord == b.ord + 32) 
                str[i], str[i+1] = "|", "|"
            end
        end
        str = str.chars.reject{|c| c == "|"}.join
    end
    str
end

# part 1
puts react_polymer(input).length

# part 2
puts (65..90).map{ |i|
    react_polymer(input.gsub(i.chr, "").gsub((i + 32).chr, "")).length
}.min