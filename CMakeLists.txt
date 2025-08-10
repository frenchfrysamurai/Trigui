cmake_minimum_required(VERSION 3.10)
project(trigui)

# Set C++ standard
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# ImGui source files
set(IMGUI_SRC
    include/imgui/imgui.cpp
    include/imgui/imgui_demo.cpp
    include/imgui/imgui_draw.cpp
    include/imgui/imgui_tables.cpp
    include/imgui/imgui_widgets.cpp
    include/imgui/imgui_impl_glfw.cpp
    include/imgui/imgui_impl_opengl3.cpp
)

# Add executable
add_executable(trigui
    trigui.cpp
    glad.c
    ${IMGUI_SRC}
)

# Include directories
target_include_directories(trigui PRIVATE
    include
    include/imgui
    ${GLFW_INCLUDE_DIRS}
)

# Find GLFW
find_package(PkgConfig REQUIRED)
pkg_search_module(GLFW REQUIRED glfw3)

# Link libraries
target_link_libraries(trigui PRIVATE
    ${GLFW_LIBRARIES}
    dl
    GL
)

# On Linux, GLFW might also need these
if(UNIX AND NOT APPLE)
  target_link_libraries(trigui PRIVATE pthread X11 Xrandr Xi Xxf86vm Xinerama Xcursor)
endif()

