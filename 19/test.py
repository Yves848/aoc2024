import sys

sys.setrecursionlimit(10**6)
DIRS = [(-1,0),(0,1),(1,0),(0,-1)] # up right down left

infile = sys.argv[1] if len(sys.argv)>=2 else '19.in'
p1 = 0
p2 = 0
D = open(infile).read().strip()
words, targets = D.split('\n\n')
words = words.split(', ')
DP = {}
def ways(words, target):
    print(f'target {target}')
    if target in DP:
        return DP[target]
    ans = 0
    if not target:
        ans = 1
    for word in words:
        if target.startswith(word):
            ans += ways(words, target[len(word):])
    DP[target] = ans
    return ans

for target in targets.split('\n'):
    print(f'Towel  {target}')
    target_ways = ways(words, target)
    if target_ways > 0:
        p1 += 1
        print(p1)
    p2 += target_ways

print(p1)
print(p2)
#print(len(DP)*len(words))