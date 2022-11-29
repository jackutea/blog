环境
1. 安装rustup
2. rustup设置toolchain
3. cargo init
4. cargo add bevy
```
5. 性能提升  **Enable Bevy's Dynamic Linking**：
	1. cargo run --features bevy/dynamic
	2. Cargo.toml
		1. bevy = {version="0.9.0", features=\["dynamic"\]}
6. 性能提升 LLD Linker:
	1. cargo install -f cargo-binutils
	2. rustup component add llvm-tools-preview

```

架构
```
use bevy::prelude::*;

// ==== Components ====
#[derive(Component)]
struct Person;
  
#[derive(Component)]
struct Name(String);

// ==== Systems ====
fn sys_add_person(mut commands: Commands) {
    commands.spawn((Person, Name("Jack".to_string())));
}

fn sys_hello() {
    println!("Hello, world!");
}

fn sys_greetings(query: Query<&Name>) {
    for name in query.iter() {
        println!("To: {}!", name.0);
    }
}

// ==== Plugins ====
pub struct  PluginHello;
impl Plugin for PluginHello {
    fn build(&self, app: &mut App) {
        app.add_startup_system(sys_add_person)
            .add_system(sys_hello)
            .add_system(sys_greetings);
    }
}

// ==== Main ====
fn main() {
    App::new()
        .add_plugins(DefaultPlugins)
        .add_plugin(PluginHello)
        .run();
}
```