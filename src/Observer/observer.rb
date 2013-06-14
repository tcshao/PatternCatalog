require 'observer'

# this is the initial class that shows how linking works, which is similiar to the Observable module
class Subject
  def initialize
    @observers = []
  end

  def add_observer(observer)
    @observers << observer
  end

  def delete_observer(observer)
    @observers.delete(observer)
  end

  def notify_observers
    @observers.each do |observer|
      observer.update(self)
    end
  end
end

class Employee
  include Observable

  attr_reader :name, :title, :salary

  def initialize( name, title, salary)
    @name = name
    @title = title
    @salary = salary
  end

  def salary=(new_salary)
    @salary = new_salary
    changed
    notify_observers(self)
  end
end

class TaxMan
  
  def update( changed_employee )
    puts("Send #{changed_employee.name} a new tax bill!")
  end

end

emp = Employee.new('Bob','My Title',394)
irs = TaxMan.new()

emp.add_observer(irs)
emp.salary = 34585
puts emp.salary


