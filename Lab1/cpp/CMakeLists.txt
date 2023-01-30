cmake_minimum_required(VERSION 3.24)
project(cpp)

set(CMAKE_CXX_STANDARD 14)

include_directories(.)

add_executable(cpp
        main.cpp
        tfraction.cpp
        tfraction.h TMixFraction.h TMixFraction.cpp)
