# Ash

An expression-oriented, dynamically typed, lexically scoped, Scheme-inspired programming language.

```
# ─────────────────────────────────────────
# Literal Values
# ─────────────────────────────────────────

# Numbers

    1
    2.71828

# Strings

    "Hello World"
    "Ready\nSet\nGo"

# Bools

    true
    false
    
# Symbols

    :foo
    :bar-baz

# ─────────────────────────────────────────
# Lists
# ─────────────────────────────────────────

# Creating Lists

    (list 1 2 3)
    (list 42 "Corge" true)
    (list 9 (list 10 11 12) 13)
    
# Count

    (count (list 1 2 3))

# Filter

    (filter
      (lambda (x) (= (% x 2) 0))
      (list 1 2 3 4 5))

# First

    (first (list 9 8 7))

# Last

    (last (list 9 8 7))

# Map

    (map 
      (lambda (x) (+ x 1))
      (list 1 2 3))

# Range

    (range 10)

# Reduce

    (reduce
      (lambda (x y) (+ x y))
      (list 1 2 3))      

# ─────────────────────────────────────────
# Comparison and Equality Operations
# ─────────────────────────────────────────

    (> 10 5)
    (< 5 10)
    (= 1 1)
    
# ─────────────────────────────────────────
# Arithmetic Operations
# ─────────────────────────────────────────

    (+ 1.1 1.1)
    (- 3 2)
    (* 4 5)
    (/ 10 2)
    (% 2 3)

# ─────────────────────────────────────────
# Let
# ─────────────────────────────────────────

    (let a 1)
    (let b "Hello World")
    (let c true)

# ─────────────────────────────────────────
# Functions
# ─────────────────────────────────────────

    (lambda (x) (x))
    
    (λ (x)
      (let a 1)
      (let b 2)
      (+ x (+ a b)))

    (let square (lambda (x) (* x x)))
    
    # ─────────────────────────────────────
    # Recursion
    # ─────────────────────────────────────
    
    (let factorial 
      (lambda (n)
        (if (= n 0)
          1
          (* n (self (- n 1))))))
            
    (print (factorial 10))

    (let fib 
      (lambda (n)
        (if (<= n 1)
          n
          (+ (self (- n 1)) (self (- n 2))))))
        
    (print (fib 14))

# ─────────────────────────────────────────
# Conditionals
# ─────────────────────────────────────────

    (if (> 1 2) "A" "B")
    (if (= a 1) "X" true)
    
# ─────────────────────────────────────────
# Console I/O
# ─────────────────────────────────────────

# Input

    (let name 
      (input "What is your name?"))
        
# Print

    (print "Hi " name "!")
    
    (print
      "West of House\n"
      "This is an open field west of a white house, with a boarded front "
      "door.\n"
      "There is a small mailbox here.\n"
      "A rubber mat saying 'Welcome to Zork!' lies by the door.")
    
    (print (list 1 2 3))
    (print true)
    (print (lambda (x) (x)))
    
# ─────────────────────────────────────────
# Random Numbers
# ─────────────────────────────────────────

    # Generate a random number between 0 and 1
    
    (let x (random))
    
# ─────────────────────────────────────────
# Working With Strings
# ─────────────────────────────────────────

    (print (string-replace "The quick brown fox" "brown" "red"))
    
# ─────────────────────────────────────────
# Records
# ─────────────────────────────────────────

    (print (record :foo 10 :bar 3.14159 :baz true))
```
