# Hole-Master
A **Casual / Puzzle** game developed with Unity.  
**Gameplay:** Control a growing black hole to collect objects, increase its size, and consume everything on the map.

![Gameplay Demo](https://github.com/maithuong-dev/Hole-Master/blob/5bf9f943815c38bbd24b637077c38d03e8aeb9d0/Gif/HoleGif.gif)

---

## Links Demo

* **Gameplay Video:** [YouTube](https://youtu.be/XV3I5SKgXkk)
* **Playable Build:** [Itch.io](https://maithuong.itch.io/hole-master)

---

## Tech Stack
- **Game Engine:** Unity 3D  
- **Programming Language:** C#  
- **Core Technologies:**  
  - Custom Shader  
  - Binary Serialization  
  - Physics Optimization

---

## Key Features

- Implemented **Singleton Pattern** for central management systems  
  (Sound, Level, Data).
- Developed a **Custom Shader (ZWrite Off)** to handle depth buffer rendering,  
  creating the visual effect of an "endless hole".
- Built a **Binary Serialization system** (using BinaryFormatter)  
  to store and load player data (Gold, Items, Levels).
- Applied **Physics Culling optimization** by activating Rigidbody components  
  only when objects are within the interaction area.

---

## Contact
* **Name:** Mai Xuân Thường
* **Email:** maithuong.dev@gmail.com
