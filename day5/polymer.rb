input = File.readlines("day5/input.txt")[0].chomp()

len = nil
until (len == input.length) do
    len = input.length
    (0...len-1).each do |i|
        a, b = input[i], input[i+1]
        if (a.ord + 32 == b.ord || a.ord == b.ord + 32) 
            input[i], input[i+1] = "|", "|"
        end
    end
    input = input.chars.reject{|c| c == "|"}.join
end

puts input.length