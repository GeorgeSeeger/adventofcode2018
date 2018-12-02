input = File.readlines("day2/input")

def hasRepeats?(id, num)
  id.chars.any?{ |c| id.chars.count{|c1| c1 == c } == num }
end 

twos = input.count{|id| hasRepeats?(id, 2)}
threes = input.count{|id| hasRepeats?(id, 3)}

puts twos * threes

## part 2
input.each do |id|
  near_match = input.select{ |id2|
    (id2.chars.select.with_index{|c2, i| c2 != id.chars[i] }).count == 1
  }.first

  if (near_match != nil)
    puts id.chars.select.with_index{|c, i| near_match[i] == c }.join
    break
  end

end