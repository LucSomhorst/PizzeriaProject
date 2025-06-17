<?php

// database/seeders/PizzaSeeder.php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Pizza;
use App\Models\Ingredient;

class PizzaSeeder extends Seeder
{
    public function run(): void
    {
        // Create 20 pizzas
        Pizza::factory()
            ->count(20)
            ->create()
            ->each(function (Pizza $pizza) {
                // Attach 2 to 5 random ingredients to each pizza
                $ingredientIds = Ingredient::inRandomOrder()->limit(rand(2, 5))->pluck('id');
                $pizza->ingredients()->attach($ingredientIds);
            });
    }
}
