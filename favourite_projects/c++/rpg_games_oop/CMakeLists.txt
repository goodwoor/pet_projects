# указание минимальной версии CMake
cmake_minimum_required(VERSION 3.18.4)

# задаём имя проекта
project(CourseWork)

# задаём версию языка с помощью передачи флагов компилятору
# флаг -g нужен для отладки проекта в gdb
set (CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -g -std=c++03")

# добавляем в переменную CPP_FILES все исходники
file (GLOB CPP_FILES "source/*.cpp")

# включение в проект заголовочных файлов
include_directories("${PROJECT_SOURCE_DIR}/include")

# компилируем исполняемый файл из исходников
add_executable(${PROJECT_NAME} ${CPP_FILES})
