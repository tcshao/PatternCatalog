class Workflow
  def process
    you_should_do_this_first
    then_you_should_do_this
    this_will_be_done_last
  end
end

class Headhunter < Workflow

  def you_should_do_this_first
    puts("Lock the target")
  end

  def then_you_should_do_this
    puts("Bait the line")
  end

  def this_will_be_done_last
    puts("Spread the net")
  end

end

template = Headhunter.new()

template.process