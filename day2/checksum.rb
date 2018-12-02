input = File.readlines("day2/input")

def hasRepeats?(id, num)
  id.chars.any?{ |c| id.chars.count{|c1| c1 == c } == num }
end 

twos = input.count{|id| hasRepeats?(id, 2)}
threes = input.count{|id| hasRepeats?(id, 3)}

puts twos * threes