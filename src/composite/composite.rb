class Task # Component
  attr_reader :name

  def initialize(name)
    @name = name
  end

  def get_time_required
    0.0
  end
end

class CompositeTask < Task

  def initialize(name)
    super(name)
    @sub_tasks = []
  end

  def add_sub_task(task)
    @sub_tasks << task
  end

  def remove_sub_task(task)
    @sub_tasks.delete(task)
  end

  def get_time_required
    time = 0.0
    @sub_tasks.each { |task| time += task.get_time_required }
    time
  end
end

class AddDryIngredients < Task

  def initialize
    super('Add dry Ingredients')
    puts 'adding dry ingredients'
  end

  def get_time_required
    1.0
  end
end

class Mix < Task

  def initialize
    super('Mix that batter up!')
    puts 'mix batter'
  end

  def get_time_required
    3.0
  end
end

class MakeBatterTask < CompositeTask

  def initialize
    super('Make Batter')
    puts 'Begin - Make Batter'
    add_sub_task( AddDryIngredients.new )
    add_sub_task( Mix.new )
    puts 'End - Make Batter'
  end
end

mbt = MakeBatterTask.new()